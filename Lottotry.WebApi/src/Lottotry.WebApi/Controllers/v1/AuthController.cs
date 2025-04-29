using Lottotry.WebApi.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Lottotry.WebApi.Databases;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Lottotry.WebApi.Domain.Users.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using System.Linq;
using Lottotry.WebApi.Services;

namespace Lottotry.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LottotryDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;
        private readonly IEmailService _emailService;

        public AuthController(LottotryDbContext context, 
                              IConfiguration config, 
                              ILogger<AuthController> logger, 
                              IEmailService emailService)
        {
            _context = context;
            _config = config;
            _logger = logger;
            _emailService = emailService;
        }


        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token)
        {
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { Success = false, Message = "Invalid token" });

            var user = _context.Users.FirstOrDefault(u => u.ConfirmationToken == token);
            if (user == null)
                return BadRequest(new { Success = false, Message = "Invalid or expired token" });

            if (user.IsConfirmed)
                return Ok(new { Success = true, Message = "Email already confirmed" });

            user.IsConfirmed = true;
            //user.ConfirmationToken = null;
            await _context.SaveChangesAsync(); 


            return Ok(new { Success = true });
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Success = false, Message = "Invalid input" });

            // Check if user exists
            if (_context.Users.Any(u => u.Email == user.Email))
            //if (_context.Users.Any(u => u.Username == user.Username))
                return BadRequest(new { Success = false, Message = "Username already registered" });

            // Generate confirmation token
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            
            user.ConfirmationToken = token;
            user.IsConfirmed = false;

            try
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash); // Install BCrypt.Net
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Send confirmation email
                var encodedToken = System.Net.WebUtility.UrlEncode(token);
                var confirmationLink = _config["ConfirmationLink"] + $"?token={encodedToken}";
                await _emailService.SendEmailAsync(
                    user.Email,
                    "Confirm Your Email",
                    $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>");

                return Ok(new { Success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering a user.");
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception:");
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "An unexpected error occurred. Please try again later.",
                });

            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == request.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    _logger.LogError("Unauthorized: username was not found or password was not matching");
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "An unexpected error occurred. Please try again later.",
                    });
                }

                var accessToken = GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    
                    Success = true,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while login a user.");
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception:");
                }

                return BadRequest(new
                {
                    Success = false,
                    Message = "An unexpected error occurred. Please try again later.",
                });

            }

        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return Unauthorized("Invalid or expired refresh token");

            var newAccessToken = GenerateJwtToken(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }


        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                new JwtHeader(creds),
                new JwtPayload(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    null,
                    DateTime.UtcNow.AddHours(1))
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}


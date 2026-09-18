namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.Services;
using Mappings;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

public static class AddUser
{
    public sealed record Command(UserForCreationDto UserToAdd) : IRequest<UserDto>;

    public sealed class Handler(LottotryDbContext dbContext, IEmailService emailService)
        : IRequestHandler<Command, UserDto>
    {
        public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userToAdd = request.UserToAdd.ToUserForCreation();
            var user = User.Create(userToAdd);

            // Generate confirmation token
            user.ConfirmationToken =
                Convert.ToBase64String(
                    RandomNumberGenerator.GetBytes(32));

            user.IsConfirmed = false;

            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            // Create verification URL
            var verificationUrl =
                $"https://ai.lottotry.com/verify-email?token=" +
                Uri.EscapeDataString(user.ConfirmationToken);

            var body = $@"
                <html>
                <body>
                    <h2>Welcome to LottoTry!</h2>

                    <p>Thank you for creating an account.</p>

                    <p>Please click the link below to verify your email address:</p>

                    <p>
                        <a href=""{verificationUrl}"">
                            Verify My Email
                        </a>
                    </p>

                    <p>If you did not create this account, you can ignore this email.</p>
                </body>
                </html>";

            await emailService.SendEmailAsync(
            user.Email,
            "Verify your LottoTry account",
            body);

            return user.ToUserDto();
        }
    }
}
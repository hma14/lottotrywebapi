namespace Lottotry.WebApi.Domain.Users.Dtos;

using Destructurama.Attributed;

public sealed record UserForUpdateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}

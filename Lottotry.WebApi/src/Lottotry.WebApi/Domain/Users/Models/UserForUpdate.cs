namespace Lottotry.WebApi.Domain.Users.Models;

using Destructurama.Attributed;

public sealed record UserForUpdate
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}

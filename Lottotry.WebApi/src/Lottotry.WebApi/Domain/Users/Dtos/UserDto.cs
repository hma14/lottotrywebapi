namespace Lottotry.WebApi.Domain.Users.Dtos;

using Destructurama.Attributed;
using System;

public sealed record UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}

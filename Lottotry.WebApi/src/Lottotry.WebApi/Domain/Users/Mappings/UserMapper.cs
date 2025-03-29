namespace Lottotry.WebApi.Domain.Users.Mappings;

using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.Domain.Users.Models;
using System.Linq;
using Mapster;


public static partial class UserMapper
{
    public static  UserForCreation ToUserForCreation(this UserForCreationDto userForCreationDto)
    {
        return new UserForCreation
        {
            Username = userForCreationDto.Username,
            Email = userForCreationDto.Email,
            PasswordHash = userForCreationDto.PasswordHash,
            Role = userForCreationDto.Role,
        };
    }
    public static  UserForUpdate ToUserForUpdate(this UserForUpdateDto userForUpdateDto)
    {
        return new UserForUpdate
        {
            Username = userForUpdateDto.Username,
            Email = userForUpdateDto.Email,
            PasswordHash = userForUpdateDto.PasswordHash,
            Role = userForUpdateDto.Role,
        };

    }
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role,
        };
    }
    public static IQueryable<UserDto> ToUserDtoQueryable(this IQueryable<User> users)
    {
        return users.Select(user => new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role,

        });
    }
}
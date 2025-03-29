namespace Lottotry.WebApi.SharedTestHelpers.Fakes.User;

using AutoBogus;
using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.Dtos;

public sealed class FakeUserForCreationDto : AutoFaker<UserForCreationDto>
{
    public FakeUserForCreationDto()
    {
        RuleFor(u => u.Email, f => f.Person.Email);
    }
}
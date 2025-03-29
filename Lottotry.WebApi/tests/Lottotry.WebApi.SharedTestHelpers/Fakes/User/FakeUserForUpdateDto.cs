namespace Lottotry.WebApi.SharedTestHelpers.Fakes.User;

using AutoBogus;
using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.Dtos;

public sealed class FakeUserForUpdateDto : AutoFaker<UserForUpdateDto>
{
    public FakeUserForUpdateDto()
    {
        RuleFor(u => u.Email, f => f.Person.Email);
    }
}
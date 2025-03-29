namespace Lottotry.WebApi.SharedTestHelpers.Fakes.User;

using AutoBogus;
using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.Models;

public sealed class FakeUserForUpdate : AutoFaker<UserForUpdate>
{
    public FakeUserForUpdate()
    {
        RuleFor(u => u.Email, f => f.Person.Email);
    }
}
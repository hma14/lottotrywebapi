namespace Lottotry.WebApi.SharedTestHelpers.Fakes.User;

using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.Models;

public class FakeUserBuilder
{
    private UserForCreation _creationData = new FakeUserForCreation().Generate();

    public FakeUserBuilder WithModel(UserForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeUserBuilder WithUsername(string username)
    {
        _creationData.Username = username;
        return this;
    }
    
    public FakeUserBuilder WithPasswordHash(string passwordHash)
    {
        _creationData.PasswordHash = passwordHash;
        return this;
    }
    
    public FakeUserBuilder WithRole(string role)
    {
        _creationData.Role = role;
        return this;
    }
    
    public User Build()
    {
        var result = User.Create(_creationData);
        return result;
    }
}
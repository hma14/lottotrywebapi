namespace Lottotry.WebApi.UnitTests.Domain.Users;

using Lottotry.WebApi.SharedTestHelpers.Fakes.User;
using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = Lottotry.WebApi.Exceptions.ValidationException;
using Xunit;
using FluentAssertions;
using System.Linq;

public class CreateUserTests
{
    private readonly Faker _faker;

    public CreateUserTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_user()
    {
        // Arrange
        var userToCreate = new FakeUserForCreation().Generate();
        
        // Act
        var user = User.Create(userToCreate);

        // Assert
        user.Username.Should().Be(userToCreate.Username);
        user.PasswordHash.Should().Be(userToCreate.PasswordHash);
        user.Role.Should().Be(userToCreate.Role);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var userToCreate = new FakeUserForCreation().Generate();
        
        // Act
        var user = User.Create(userToCreate);

        // Assert
        user.Should().Be(1);
        user.Should().BeOfType(typeof(UserCreated));
    }
}
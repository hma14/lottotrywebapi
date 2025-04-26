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

public class UpdateUserTests
{
    private readonly Faker _faker;

    public UpdateUserTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_user()
    {
        // Arrange
        var user = new FakeUserBuilder().Build();
        var updatedUser = new FakeUserForUpdate().Generate();
        
        // Act
        user.Update(updatedUser);

        // Assert
        user.Username.Should().Be(updatedUser.Username);
        user.PasswordHash.Should().Be(updatedUser.PasswordHash);
        user.Role.Should().Be(updatedUser.Role);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var user = new FakeUserBuilder().Build();
        var updatedUser = new FakeUserForUpdate().Generate();
        //user.DomainEvents.Clear();
        
        // Act
        user.Update(updatedUser);

        // Assert
        user.Should().Be(1);
        user.Should().BeOfType(typeof(UserUpdated));
    }
}
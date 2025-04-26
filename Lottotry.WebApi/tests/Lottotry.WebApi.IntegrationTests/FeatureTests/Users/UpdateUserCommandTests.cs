namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Users;

using Lottotry.WebApi.SharedTestHelpers.Fakes.User;
using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.Domain.Users.Features;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using MediatR;
using FluentAssertions;

public class UpdateUserCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_user_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOne = new FakeUserBuilder().Build();
        var updatedUserDto = new FakeUserForUpdateDto().Generate();
        await testingServiceScope.InsertAsync(userOne);

        var user = await testingServiceScope.ExecuteDbContextAsync(db => db.Users
            .FirstOrDefaultAsync(u => u.Id == userOne.Id));
        var id = user.Id;

        // Act
        var command = new UpdateUser.Command(id, updatedUserDto);
        await testingServiceScope.SendAsync(command);
        var updatedUser = await testingServiceScope.ExecuteDbContextAsync(db => db.Users.FirstOrDefaultAsync(u => u.Id == id));

        // Assert
        //updatedUser?.FirstName.Should().Be(updatedUserDto.FirstName);
        //updatedUser?.LastName.Should().Be(updatedUserDto.LastName);
        updatedUser?.Username.Should().Be(updatedUserDto.Username);
        //updatedUser?.Identifier.Should().Be(updatedUserDto.Identifier);
        updatedUser?.Email.Should().Be(updatedUserDto.Email);
    }
}
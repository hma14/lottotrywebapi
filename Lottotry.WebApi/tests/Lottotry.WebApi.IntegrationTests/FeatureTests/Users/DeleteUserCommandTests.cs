namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Users;

using Lottotry.WebApi.SharedTestHelpers.Fakes.User;
using Lottotry.WebApi.Domain.Users.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;
using Xunit;
using System;
using FluentAssertions;
using Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

public class DeleteUserCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_user_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var user = new FakeUserBuilder().Build();
        await testingServiceScope.InsertAsync(user);

        // Act
        var command = new DeleteUser.Command(user.Id);
        await testingServiceScope.SendAsync(command);
        var userResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Users
                .CountAsync(u => u.Id == user.Id));

        // Assert
        userResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_user_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = 9;

        // Act
        var command = new DeleteUser.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
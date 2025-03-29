namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Users;

using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.SharedTestHelpers.Fakes.User;
using Lottotry.WebApi.Domain.Users.Features;
using Domain;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Linq;

public class GetAllUsersQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_all_users()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOne = new FakeUserBuilder().Build();
        var userTwo = new FakeUserBuilder().Build();

        await testingServiceScope.InsertAsync(userOne, userTwo);

        // Act
        var query = new GetAllUsers.Query();
        var users = await testingServiceScope.SendAsync(query);

        // Assert
        users.Count.Should().BeGreaterThanOrEqualTo(2);

        users.FirstOrDefault(x => x.Id == userOne.Id).Should().NotBeNull();
        users.FirstOrDefault(x => x.Id == userTwo.Id).Should().NotBeNull();
    }
}
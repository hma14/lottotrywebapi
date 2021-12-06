namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class CreateNumberTests : TestBase
{
    [Test]
    public async Task create_number_returns_created_using_valid_dto()
    {
        // Arrange
        var fakeNumber = new FakeNumberForCreationDto { }.Generate();

        // Act
        var route = ApiRoutes.Numbers.Create;
        var result = await _client.PostJsonRequestAsync(route, fakeNumber);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
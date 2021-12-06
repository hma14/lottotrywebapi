namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class DeleteNumberTests : TestBase
{
    [Test]
    public async Task delete_number_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var fakeNumber = new FakeNumber { }.Generate();
        await InsertAsync(fakeNumber);

        // Act
        var route = ApiRoutes.Numbers.Delete.Replace(ApiRoutes.Numbers.Id, fakeNumber.Id.ToString());
        var result = await _client.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
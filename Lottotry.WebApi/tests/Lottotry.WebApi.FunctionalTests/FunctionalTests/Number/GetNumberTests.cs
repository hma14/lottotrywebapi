namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class GetNumberTests : TestBase
{
    [Test]
    public async Task get_number_returns_success_when_entity_exists()
    {
        // Arrange
        var fakeNumber = new FakeNumber { }.Generate();
        await InsertAsync(fakeNumber);

        // Act
        var route = ApiRoutes.Numbers.GetRecord.Replace(ApiRoutes.Numbers.Id, fakeNumber.Id.ToString());
        var result = await _client.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
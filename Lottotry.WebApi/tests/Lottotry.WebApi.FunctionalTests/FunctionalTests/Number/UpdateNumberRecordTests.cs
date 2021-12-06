namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class UpdateNumberRecordTests : TestBase
{
    [Test]
    public async Task put_number_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var fakeNumber = new FakeNumber { }.Generate();
        var updatedNumberDto = new FakeNumberForUpdateDto { }.Generate();
        await InsertAsync(fakeNumber);

        // Act
        var route = ApiRoutes.Numbers.Put.Replace(ApiRoutes.Numbers.Id, fakeNumber.Id.ToString());
        var result = await _client.PutJsonRequestAsync(route, updatedNumberDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class UpdateLottoTypeRecordTests : TestBase
{
    [Test]
    public async Task put_lottotype_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var fakeLottoType = new FakeLottoType { }.Generate();
        var updatedLottoTypeDto = new FakeLottoTypeForUpdateDto { }.Generate();
        await InsertAsync(fakeLottoType);

        // Act
        var route = ApiRoutes.LottoTypes.Put.Replace(ApiRoutes.LottoTypes.Id, fakeLottoType.Id.ToString());
        var result = await _client.PutJsonRequestAsync(route, updatedLottoTypeDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class GetLottoTypeTests : TestBase
{
    [Test]
    public async Task get_lottotype_returns_success_when_entity_exists()
    {
        // Arrange
        var fakeLottoType = new FakeLottoType { }.Generate();
        await InsertAsync(fakeLottoType);

        // Act
        var route = ApiRoutes.LottoTypes.GetRecord.Replace(ApiRoutes.LottoTypes.Id, fakeLottoType.Id.ToString());
        var result = await _client.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
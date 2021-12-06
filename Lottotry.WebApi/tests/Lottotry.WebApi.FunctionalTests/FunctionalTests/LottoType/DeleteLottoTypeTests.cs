namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class DeleteLottoTypeTests : TestBase
{
    [Test]
    public async Task delete_lottotype_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var fakeLottoType = new FakeLottoType { }.Generate();
        await InsertAsync(fakeLottoType);

        // Act
        var route = ApiRoutes.LottoTypes.Delete.Replace(ApiRoutes.LottoTypes.Id, fakeLottoType.Id.ToString());
        var result = await _client.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
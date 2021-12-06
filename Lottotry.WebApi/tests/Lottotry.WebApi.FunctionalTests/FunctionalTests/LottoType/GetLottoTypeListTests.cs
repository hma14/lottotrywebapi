namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class GetLottoTypeListTests : TestBase
{
    [Test]
    public async Task get_lottotype_list_returns_success()
    {
        // Arrange
        // N/A

        // Act
        var result = await _client.GetRequestAsync(ApiRoutes.LottoTypes.GetList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
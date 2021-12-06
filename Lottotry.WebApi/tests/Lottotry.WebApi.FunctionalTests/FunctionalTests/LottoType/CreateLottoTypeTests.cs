namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class CreateLottoTypeTests : TestBase
{
    [Test]
    public async Task create_lottotype_returns_created_using_valid_dto()
    {
        // Arrange
        var fakeLottoType = new FakeLottoTypeForCreationDto { }.Generate();

        // Act
        var route = ApiRoutes.LottoTypes.Create;
        var result = await _client.PostJsonRequestAsync(route, fakeLottoType);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
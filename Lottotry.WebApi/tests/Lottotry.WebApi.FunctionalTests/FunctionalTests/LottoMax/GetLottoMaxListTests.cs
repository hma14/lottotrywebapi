namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GetLottoMaxListTests : TestBase
    {
        [Test]
        public async Task Get_LottoMax_List_Returns_200()
        {
            // Arrange
            // N/A

            // Act
            var result = await _client.GetRequestAsync(ApiRoutes.LottoMax.GetList);

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
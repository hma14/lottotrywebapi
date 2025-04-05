namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class GetLottoNumbersListTests : TestBase
    {
        [Test]
        public async Task Get_LottoNumbers_List_Returns_200()
        {
            // Arrange
            // N/A

            // Act
            var result = await _client.GetRequestAsync(ApiRoutes.LottoNumbers.GetList);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)200);
        }
    }
}
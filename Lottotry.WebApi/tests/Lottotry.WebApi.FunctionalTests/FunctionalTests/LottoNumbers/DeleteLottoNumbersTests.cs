namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class DeleteLottoNumbersTests : TestBase
    {
        [Test]
        public async Task Delete_LottoNumbersReturns_NoContent()
        {
            // Arrange
            var fakeLottoNumbers = new FakeLottoNumbers { }.Generate();
            await InsertAsync(fakeLottoNumbers);

            // Act
            var route = ApiRoutes.LottoNumbers.Delete.Replace(ApiRoutes.LottoNumbers.LottoName, fakeLottoNumbers.LottoName.ToString());
            var result = await _client.DeleteRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)204);
        }
    }
}
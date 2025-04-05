namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class UpdateLottoMaxRecordTests : TestBase
    {
        [Test]
        public async Task Put_LottoMax_Returns_NoContent()
        {
            // Arrange
            var fakeLottoMax = new FakeLottoMax { }.Generate();
            var updatedLottoMaxDto = new FakeLottoMaxForUpdateDto { }.Generate();
            await InsertAsync(fakeLottoMax);

            // Act
            var route = ApiRoutes.LottoMax.Put.Replace(ApiRoutes.LottoMax.DrawNumber, fakeLottoMax.DrawNumber.ToString());
            var result = await _client.PutJsonRequestAsync(route, updatedLottoMaxDto);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)204);
        }
    }
}
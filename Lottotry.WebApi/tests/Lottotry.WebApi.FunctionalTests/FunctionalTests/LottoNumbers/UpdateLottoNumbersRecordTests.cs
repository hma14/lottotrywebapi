namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class UpdateLottoNumbersRecordTests : TestBase
    {
        [Test]
        public async Task Put_LottoNumbers_Returns_NoContent()
        {
            // Arrange
            var fakeLottoNumbers = new FakeLottoNumbers { }.Generate();
            var updatedLottoNumbersDto = new FakeLottoNumbersForUpdateDto { }.Generate();
            await InsertAsync(fakeLottoNumbers);

            // Act
            var route = ApiRoutes.LottoNumbers.Put.Replace(ApiRoutes.LottoNumbers.LottoName, fakeLottoNumbers.LottoName.ToString());
            var result = await _client.PutJsonRequestAsync(route, updatedLottoNumbersDto);

            // Assert
            result.StatusCode.Should().Be(204);
        }
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GetLottoNumbersTests : TestBase
    {
        [Test]
        public async Task Get_LottoNumbers_Record_Returns_200()
        {
            // Arrange
            var fakeLottoNumbers = new FakeLottoNumbers { }.Generate();
            await InsertAsync(fakeLottoNumbers);

            // Act
            var route = ApiRoutes.LottoNumbers.GetRecord.Replace(ApiRoutes.LottoNumbers.LottoName, fakeLottoNumbers.LottoName.ToString());
            var result = await _client.GetRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
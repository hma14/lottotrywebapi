namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GetLottoMaxTests : TestBase
    {
        [Test]
        public async Task Get_LottoMax_Record_Returns_200()
        {
            // Arrange
            var fakeLottoMax = new FakeLottoMax { }.Generate();
            await InsertAsync(fakeLottoMax);

            // Act
            var route = ApiRoutes.LottoMax.GetRecord.Replace(ApiRoutes.LottoMax.DrawNumber, fakeLottoMax.DrawNumber.ToString());
            var result = await _client.GetRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
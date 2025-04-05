namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class DeleteLottoMaxTests : TestBase
    {
        [Test]
        public async Task Delete_LottoMaxReturns_NoContent()
        {
            // Arrange
            var fakeLottoMax = new FakeLottoMax { }.Generate();
            await InsertAsync(fakeLottoMax);

            // Act
            var route = ApiRoutes.LottoMax.Delete.Replace(ApiRoutes.LottoMax.DrawNumber, fakeLottoMax.DrawNumber.ToString());
            var result = await _client.DeleteRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)204);
        }
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class CreateLottoMaxTests : TestBase
    {
        [Test]
        public async Task Create_LottoMax_Returns_Created()
        {
            // Arrange
            var fakeLottoMax = new FakeLottoMaxForCreationDto { }.Generate();

            // Act
            var route = ApiRoutes.LottoMax.Create;
            var result = await _client.PostJsonRequestAsync(route, fakeLottoMax);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)201);
        }
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CreateLottoNumbersTests : TestBase
    {
        [Test]
        public async Task Create_LottoNumbers_Returns_Created()
        {
            // Arrange
            var fakeLottoNumbers = new FakeLottoNumbersForCreationDto { }.Generate();

            // Act
            var route = ApiRoutes.LottoNumbers.Create;
            var result = await _client.PostJsonRequestAsync(route, fakeLottoNumbers);

            // Assert
            result.StatusCode.Should().Be(201);
        }
    }
}
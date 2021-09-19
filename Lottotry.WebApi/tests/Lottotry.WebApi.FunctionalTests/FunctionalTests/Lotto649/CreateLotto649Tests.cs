namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CreateLotto649Tests : TestBase
    {
        [Test]
        public async Task Create_Lotto649_Returns_Created()
        {
            // Arrange
            var fakeLotto649 = new FakeLotto649ForCreationDto { }.Generate();

            // Act
            var route = ApiRoutes.Lotto649.Create;
            var result = await _client.PostJsonRequestAsync(route, fakeLotto649);

            // Assert
            result.StatusCode.Should().Be(201);
        }
    }
}
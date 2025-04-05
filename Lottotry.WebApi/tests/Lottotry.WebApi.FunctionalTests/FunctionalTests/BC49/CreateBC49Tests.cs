namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class CreateBC49Tests : TestBase
    {
        [Test]
        public async Task Create_BC49_Returns_Created()
        {
            // Arrange
            var fakeBC49 = new FakeBC49ForCreationDto { }.Generate();

            // Act
            var route = ApiRoutes.BC49.Create;
            var result = await _client.PostJsonRequestAsync(route, fakeBC49);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
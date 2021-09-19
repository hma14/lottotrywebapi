namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GetBC49ListTests : TestBase
    {
        [Test]
        public async Task Get_BC49_List_Returns_200()
        {
            // Arrange
            // N/A

            // Act
            var result = await _client.GetRequestAsync(ApiRoutes.BC49.GetList);

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
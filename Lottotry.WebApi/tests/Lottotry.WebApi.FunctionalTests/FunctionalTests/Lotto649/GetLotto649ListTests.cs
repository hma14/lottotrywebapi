namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GetLotto649ListTests : TestBase
    {
        [Test]
        public async Task Get_Lotto649_List_Returns_200()
        {
            // Arrange
            // N/A

            // Act
            var result = await _client.GetRequestAsync(ApiRoutes.Lotto649.GetList);

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class DeleteLotto649Tests : TestBase
    {
        [Test]
        public async Task Delete_Lotto649Returns_NoContent()
        {
            // Arrange
            var fakeLotto649 = new FakeLotto649 { }.Generate();
            await InsertAsync(fakeLotto649);

            // Act
            var route = ApiRoutes.Lotto649.Delete.Replace(ApiRoutes.Lotto649.DrawNumber, fakeLotto649.DrawNumber.ToString());
            var result = await _client.DeleteRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be(204);
        }
    }
}
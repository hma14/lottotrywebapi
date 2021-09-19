namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class DeleteBC49Tests : TestBase
    {
        [Test]
        public async Task Delete_BC49Returns_NoContent()
        {
            // Arrange
            var fakeBC49 = new FakeBC49 { }.Generate();
            await InsertAsync(fakeBC49);

            // Act
            var route = ApiRoutes.BC49.Delete.Replace(ApiRoutes.BC49.DrawNumber, fakeBC49.DrawNumber.ToString());
            var result = await _client.DeleteRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be(204);
        }
    }
}
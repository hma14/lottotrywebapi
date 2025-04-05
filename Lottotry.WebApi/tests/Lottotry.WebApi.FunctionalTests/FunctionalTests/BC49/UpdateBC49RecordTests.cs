namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class UpdateBC49RecordTests : TestBase
    {
        [Test]
        public async Task Put_BC49_Returns_NoContent()
        {
            // Arrange
            var fakeBC49 = new FakeBC49 { }.Generate();
            var updatedBC49Dto = new FakeBC49ForUpdateDto { }.Generate();
            await InsertAsync(fakeBC49);

            // Act
            var route = ApiRoutes.BC49.Put.Replace(ApiRoutes.BC49.DrawNumber, fakeBC49.DrawNumber.ToString());
            var result = await _client.PutJsonRequestAsync(route, updatedBC49Dto);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode) 204);
        }
    }
}
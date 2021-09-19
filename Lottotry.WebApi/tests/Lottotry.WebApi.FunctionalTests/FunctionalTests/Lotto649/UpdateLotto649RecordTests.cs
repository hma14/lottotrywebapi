namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class UpdateLotto649RecordTests : TestBase
    {
        [Test]
        public async Task Put_Lotto649_Returns_NoContent()
        {
            // Arrange
            var fakeLotto649 = new FakeLotto649 { }.Generate();
            var updatedLotto649Dto = new FakeLotto649ForUpdateDto { }.Generate();
            await InsertAsync(fakeLotto649);

            // Act
            var route = ApiRoutes.Lotto649.Put.Replace(ApiRoutes.Lotto649.DrawNumber, fakeLotto649.DrawNumber.ToString());
            var result = await _client.PutJsonRequestAsync(route, updatedLotto649Dto);

            // Assert
            result.StatusCode.Should().Be(204);
        }
    }
}
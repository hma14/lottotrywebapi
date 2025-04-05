namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class GetBC49Tests : TestBase
    {
        [Test]
        public async Task Get_BC49_Record_Returns_200()
        {
            // Arrange
            var fakeBC49 = new FakeBC49 { }.Generate();
            await InsertAsync(fakeBC49);

            // Act
            var route = ApiRoutes.BC49.GetRecord.Replace(ApiRoutes.BC49.DrawNumber, fakeBC49.DrawNumber.ToString());
            var result = await _client.GetRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
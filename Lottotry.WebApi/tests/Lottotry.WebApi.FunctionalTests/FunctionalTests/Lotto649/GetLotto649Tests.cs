namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class GetLotto649Tests : TestBase
    {
        [Test]
        public async Task Get_Lotto649_Record_Returns_200()
        {
            // Arrange
            var fakeLotto649 = new FakeLotto649 { }.Generate();
            await InsertAsync(fakeLotto649);

            // Act
            var route = ApiRoutes.Lotto649.GetRecord.Replace(ApiRoutes.Lotto649.DrawNumber, fakeLotto649.DrawNumber.ToString());
            var result = await _client.GetRequestAsync(route);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)200);
        }
    }
}
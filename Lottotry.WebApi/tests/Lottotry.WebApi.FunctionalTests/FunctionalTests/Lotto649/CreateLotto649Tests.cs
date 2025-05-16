namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;
    using System;

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
            if (result.StatusCode != HttpStatusCode.Created)
            {
                var errorContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {result.StatusCode} - {errorContent}");
                Assert.Fail($"Request failed: {errorContent}");
            }
            result.StatusCode.Should().Be((HttpStatusCode)201);
        }
    }
}
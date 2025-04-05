namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.HealthChecks
{
    using Lottotry.WebApi.FunctionalTests.TestUtilities;
    using FluentAssertions;
    using NUnit.Framework;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Net;

    public class HealthCheckTests : TestBase
    {
        [Test]
        public async Task Health_Check_Returns_Ok()
        {
            // Arrange
            // N/A

            // Act
            var result = await _client.GetRequestAsync(ApiRoutes.Health);

            // Assert
            result.StatusCode.Should().Be((HttpStatusCode)200);
        }
    }
}
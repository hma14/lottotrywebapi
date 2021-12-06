namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

public class GetNumberListTests : TestBase
{
    [Test]
    public async Task get_number_list_returns_success()
    {
        // Arrange
        // N/A

        // Act
        var result = await _client.GetRequestAsync(ApiRoutes.Numbers.GetList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
namespace Lottotry.WebApi.FunctionalTests.FunctionalTests.Number;

using Lottotry.WebApi.Dtos.Number;
using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.FunctionalTests.TestUtilities;
using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class AddNumberListTests : TestBase
{
    [Test]
    public async Task create_number_list_returns_created_using_valid_dto()
    {
        // Arrange
        var fakeLottoType = new FakeLottoType() { }.Generate();
        await InsertAsync(fakeLottoType);
        var fakeNumberList = new List<NumberForCreationDto> {new FakeNumberForCreationDto { }.Generate()};

        // Act
        var route = ApiRoutes.Numbers.Create;
        var result = await _client.PostJsonRequestAsync($"{route}?lottotypeid={fakeLottoType.Id}", fakeNumberList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    [Test]
    public async Task create_number_list_returns_notfound_when_fk_doesnt_exist()
    {
        // Arrange
        var fakeNumberList = new List<NumberForCreationDto> {new FakeNumberForCreationDto { }.Generate()};

        // Act
        var route = ApiRoutes.Numbers.Create;
        var result = await _client.PostJsonRequestAsync($"{route}?lottotypeid={Guid.NewGuid()}", fakeNumberList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    [Test]
    public async Task create_number_list_returns_badrequest_when_no_fk_param()
    {
        // Arrange
        var fakeNumberList = new List<NumberForCreationDto> {new FakeNumberForCreationDto { }.Generate()};

        // Act
        var result = await _client.PostJsonRequestAsync(ApiRoutes.Numbers.Create, fakeNumberList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
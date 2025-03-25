namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using FluentAssertions;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Lottotry.WebApi.Domain.LottoTypes.Features;
using static TestFixture;
using System;
using Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

public class LottoTypeQueryTests : TestBase
{
    [Test]
    public async Task can_get_existing_lottotype_with_accurate_props()
    {
        // Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        await InsertAsync(fakeLottoTypeOne);

        // Act
        var query = new GetLottoType.LottoTypeQuery(fakeLottoTypeOne.Id);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().BeEquivalentTo(fakeLottoTypeOne, options =>
            options.ExcludingMissingMembers());
    }

    [Test]
    public async Task get_lottotype_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var badId = Guid.NewGuid();

        // Act
        var query = new GetLottoType.LottoTypeQuery(badId);
        Func<Task> act = () => SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}

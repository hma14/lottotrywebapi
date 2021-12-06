namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using Lottotry.WebApi.Dtos.LottoType;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Lottotry.WebApi.Domain.LottoTypes.Features;
using static TestFixture;

public class UpdateLottoTypeCommandTests : TestBase
{
    [Test]
    public async Task can_update_existing_lottotype_in_db()
    {
        // Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var updatedLottoTypeDto = new FakeLottoTypeForUpdateDto { }.Generate();
        await InsertAsync(fakeLottoTypeOne);

        var lottoType = await ExecuteDbContextAsync(db => db.LottoTypes.SingleOrDefaultAsync());
        var id = lottoType.Id;

        // Act
        var command = new UpdateLottoType.UpdateLottoTypeCommand(id, updatedLottoTypeDto);
        await SendAsync(command);
        var updatedLottoType = await ExecuteDbContextAsync(db => db.LottoTypes.Where(l => l.Id == id).SingleOrDefaultAsync());

        // Assert
        updatedLottoType.Should().BeEquivalentTo(updatedLottoTypeDto, options =>
            options.ExcludingMissingMembers());
    }
}
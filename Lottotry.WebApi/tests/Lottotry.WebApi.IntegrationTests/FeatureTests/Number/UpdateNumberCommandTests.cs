namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using Lottotry.WebApi.Dtos.Number;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Lottotry.WebApi.Domain.Numbers.Features;
using static TestFixture;

public class UpdateNumberCommandTests : TestBase
{
    [Test]
    public async Task can_update_existing_number_in_db()
    {
        // Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var updatedNumberDto = new FakeNumberForUpdateDto { }.Generate();
        await InsertAsync(fakeNumberOne);

        var number = await ExecuteDbContextAsync(db => db.Numbers.SingleOrDefaultAsync());
        var id = number.Id;

        // Act
        var command = new UpdateNumber.UpdateNumberCommand(id, updatedNumberDto);
        await SendAsync(command);
        var updatedNumber = await ExecuteDbContextAsync(db => db.Numbers.Where(n => n.Id == id).SingleOrDefaultAsync());

        // Assert
        updatedNumber.Should().BeEquivalentTo(updatedNumberDto, options =>
            options.ExcludingMissingMembers());
    }
}
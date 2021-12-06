namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

using Lottotry.WebApi.Dtos.Number;
using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using Lottotry.WebApi.Domain.Numbers.Features;
using Lottotry.WebApi.Exceptions;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using static TestFixture;

public class AddNumberCommandTests : TestBase
{
    [Test]
    public async Task can_add_new_number_list_to_db()
    {
        // Arrange
        var fakeLottoType = new FakeLottoType { }.Generate();
        await InsertAsync(fakeLottoType);
        var fakeNumberOne = new FakeNumberForCreationDto { }.Generate();

        // Act
        var command = new AddNumberList.AddNumberListCommand(new List<NumberForCreationDto>() {fakeNumberOne}, fakeLottoType.Id);
        var numberReturned = await SendAsync(command);
        var numberCreated = await ExecuteDbContextAsync(db => db.Numbers.SingleOrDefaultAsync());

        // Assert
        numberReturned.FirstOrDefault().Should().BeEquivalentTo(fakeNumberOne, options =>
            options.ExcludingMissingMembers());
        numberCreated.Should().BeEquivalentTo(fakeNumberOne, options =>
            options.ExcludingMissingMembers());
    }
}
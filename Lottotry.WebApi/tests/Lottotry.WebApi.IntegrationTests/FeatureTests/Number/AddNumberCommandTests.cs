namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Lottotry.WebApi.Domain.Numbers.Features;
using static TestFixture;
using Lottotry.WebApi.Exceptions;

public class AddNumberCommandTests : TestBase
{
    [Test]
    public async Task can_add_new_number_to_db()
    {
        // Arrange
        var fakeNumberOne = new FakeNumberForCreationDto { }.Generate();

        // Act
        var command = new AddNumber.AddNumberCommand(fakeNumberOne);
        var numberReturned = await SendAsync(command);
        var numberCreated = await ExecuteDbContextAsync(db => db.Numbers.SingleOrDefaultAsync());

        // Assert
        numberReturned.Should().BeEquivalentTo(fakeNumberOne, options =>
            options.ExcludingMissingMembers());
        numberCreated.Should().BeEquivalentTo(fakeNumberOne, options =>
            options.ExcludingMissingMembers());
    }
}
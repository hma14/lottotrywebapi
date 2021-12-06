namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Lottotry.WebApi.Domain.LottoTypes.Features;
using static TestFixture;
using Lottotry.WebApi.Exceptions;

public class AddLottoTypeCommandTests : TestBase
{
    [Test]
    public async Task can_add_new_lottotype_to_db()
    {
        // Arrange
        var fakeLottoTypeOne = new FakeLottoTypeForCreationDto { }.Generate();

        // Act
        var command = new AddLottoType.AddLottoTypeCommand(fakeLottoTypeOne);
        var lottoTypeReturned = await SendAsync(command);
        var lottoTypeCreated = await ExecuteDbContextAsync(db => db.LottoTypes.SingleOrDefaultAsync());

        // Assert
        lottoTypeReturned.Should().BeEquivalentTo(fakeLottoTypeOne, options =>
            options.ExcludingMissingMembers());
        lottoTypeCreated.Should().BeEquivalentTo(fakeLottoTypeOne, options =>
            options.ExcludingMissingMembers());
    }
}
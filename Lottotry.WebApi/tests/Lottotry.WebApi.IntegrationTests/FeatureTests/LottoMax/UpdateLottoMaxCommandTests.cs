namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using Lottotry.WebApi.Dtos.LottoMax;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.JsonPatch;
    using System.Linq;
    using Lottotry.WebApi.Domain.LottoMax.Features;
    using static TestFixture;

    public class UpdateLottoMaxCommandTests : TestBase
    {
        [Test]
        public async Task UpdateLottoMaxCommand_Updates_Existing_LottoMax_In_Db()
        {
            // Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var updatedLottoMaxDto = new FakeLottoMaxForUpdateDto { }.Generate();
            await InsertAsync(fakeLottoMaxOne);

            var lottoMax = await ExecuteDbContextAsync(db => db.LottoMax.SingleOrDefaultAsync());
            var drawNumber = lottoMax.DrawNumber;

            // Act
            var command = new UpdateLottoMax.UpdateLottoMaxCommand(drawNumber, updatedLottoMaxDto);
            await SendAsync(command);
            var updatedLottoMax = await ExecuteDbContextAsync(db => db.LottoMax.Where(l => l.DrawNumber == drawNumber).SingleOrDefaultAsync());

            // Assert
            updatedLottoMax.Should().BeEquivalentTo(updatedLottoMaxDto, options =>
                options.ExcludingMissingMembers());
        }
    }
}
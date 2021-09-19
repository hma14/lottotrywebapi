namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using Lottotry.WebApi.Dtos.Lotto649;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.JsonPatch;
    using System.Linq;
    using Lottotry.WebApi.Domain.Lotto649.Features;
    using static TestFixture;

    public class UpdateLotto649CommandTests : TestBase
    {
        [Test]
        public async Task UpdateLotto649Command_Updates_Existing_Lotto649_In_Db()
        {
            // Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var updatedLotto649Dto = new FakeLotto649ForUpdateDto { }.Generate();
            await InsertAsync(fakeLotto649One);

            var lotto649 = await ExecuteDbContextAsync(db => db.Lotto649.SingleOrDefaultAsync());
            var drawNumber = lotto649.DrawNumber;

            // Act
            var command = new UpdateLotto649.UpdateLotto649Command(drawNumber, updatedLotto649Dto);
            await SendAsync(command);
            var updatedLotto649 = await ExecuteDbContextAsync(db => db.Lotto649.Where(l => l.DrawNumber == drawNumber).SingleOrDefaultAsync());

            // Assert
            updatedLotto649.Should().BeEquivalentTo(updatedLotto649Dto, options =>
                options.ExcludingMissingMembers());
        }
    }
}
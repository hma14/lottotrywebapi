namespace Lottotry.WebApi.IntegrationTests.FeatureTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using Lottotry.WebApi.Dtos.BC49;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.JsonPatch;
    using System.Linq;
    using Lottotry.WebApi.Domain.BC49.Features;
    using static TestFixture;

    public class UpdateBC49CommandTests : TestBase
    {
        [Test]
        public async Task UpdateBC49Command_Updates_Existing_BC49_In_Db()
        {
            // Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var updatedBC49Dto = new FakeBC49ForUpdateDto { }.Generate();
            await InsertAsync(fakeBC49One);

            var bC49 = await ExecuteDbContextAsync(db => db.BC49.SingleOrDefaultAsync());
            var drawNumber = bC49.DrawNumber;

            // Act
            var command = new UpdateBC49.UpdateBC49Command(drawNumber, updatedBC49Dto);
            await SendAsync(command);
            var updatedBC49 = await ExecuteDbContextAsync(db => db.BC49.Where(b => b.DrawNumber == drawNumber).SingleOrDefaultAsync());

            // Assert
            updatedBC49.Should().BeEquivalentTo(updatedBC49Dto, options =>
                options.ExcludingMissingMembers());
        }
    }
}
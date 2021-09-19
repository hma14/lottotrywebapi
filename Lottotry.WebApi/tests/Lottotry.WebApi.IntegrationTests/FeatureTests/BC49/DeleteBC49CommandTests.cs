namespace Lottotry.WebApi.IntegrationTests.FeatureTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.BC49.Features;
    using static TestFixture;

    public class DeleteBC49CommandTests : TestBase
    {
        [Test]
        public async Task DeleteBC49Command_Deletes_BC49_From_Db()
        {
            // Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            await InsertAsync(fakeBC49One);
            var bC49 = await ExecuteDbContextAsync(db => db.BC49.SingleOrDefaultAsync());
            var drawNumber = bC49.DrawNumber;

            // Act
            var command = new DeleteBC49.DeleteBC49Command(drawNumber);
            await SendAsync(command);
            var bC49 = await ExecuteDbContextAsync(db => db.BC49.ToListAsync());

            // Assert
            bC49.Count.Should().Be(0);
        }

        [Test]
        public async Task DeleteBC49Command_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var command = new DeleteBC49.DeleteBC49Command(badId);
            Func<Task> act = () => SendAsync(command);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
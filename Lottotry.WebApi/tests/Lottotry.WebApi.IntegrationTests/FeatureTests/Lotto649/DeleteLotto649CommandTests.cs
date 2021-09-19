namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.Lotto649.Features;
    using static TestFixture;

    public class DeleteLotto649CommandTests : TestBase
    {
        [Test]
        public async Task DeleteLotto649Command_Deletes_Lotto649_From_Db()
        {
            // Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            await InsertAsync(fakeLotto649One);
            var lotto649 = await ExecuteDbContextAsync(db => db.Lotto649.SingleOrDefaultAsync());
            var drawNumber = lotto649.DrawNumber;

            // Act
            var command = new DeleteLotto649.DeleteLotto649Command(drawNumber);
            await SendAsync(command);
            var lotto649 = await ExecuteDbContextAsync(db => db.Lotto649.ToListAsync());

            // Assert
            lotto649.Count.Should().Be(0);
        }

        [Test]
        public async Task DeleteLotto649Command_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var command = new DeleteLotto649.DeleteLotto649Command(badId);
            Func<Task> act = () => SendAsync(command);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
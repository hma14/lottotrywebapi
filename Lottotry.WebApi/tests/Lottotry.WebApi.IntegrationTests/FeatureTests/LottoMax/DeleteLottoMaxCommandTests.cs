namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.LottoMax.Features;
    using static TestFixture;

    public class DeleteLottoMaxCommandTests : TestBase
    {
        [Test]
        public async Task DeleteLottoMaxCommand_Deletes_LottoMax_From_Db()
        {
            // Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            await InsertAsync(fakeLottoMaxOne);
            var lottoMax = await ExecuteDbContextAsync(db => db.LottoMax.SingleOrDefaultAsync());
            var drawNumber = lottoMax.DrawNumber;

            // Act
            var command = new DeleteLottoMax.DeleteLottoMaxCommand(drawNumber);
            await SendAsync(command);
            var lotto = await ExecuteDbContextAsync(db => db.LottoMax.ToListAsync());

            // Assert
            lotto.Count.Should().Be(0);
        }

        [Test]
        public async Task DeleteLottoMaxCommand_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var command = new DeleteLottoMax.DeleteLottoMaxCommand(badId);
            Func<Task> act = () => SendAsync(command);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.LottoNumbers.Features;
    using static TestFixture;

    public class DeleteLottoNumbersCommandTests : TestBase
    {
        [Test]
        public async Task DeleteLottoNumbersCommand_Deletes_LottoNumbers_From_Db()
        {
            // Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            await InsertAsync(fakeLottoNumbersOne);
            var lottoNumbers = await ExecuteDbContextAsync(db => db.LottoNumbers.SingleOrDefaultAsync());
            var lottoName = lottoNumbers.LottoName;

            // Act
            var command = new DeleteLottoNumbers.DeleteLottoNumbersCommand(lottoName);
            await SendAsync(command);
            var lotto = await ExecuteDbContextAsync(db => db.LottoNumbers.ToListAsync());

            // Assert
            lotto.Count.Should().Be(0);
        }

        [Test]
        public async Task DeleteLottoNumbersCommand_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var command = new DeleteLottoNumbers.DeleteLottoNumbersCommand(badId);
            Func<Task> act = () => SendAsync(command);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
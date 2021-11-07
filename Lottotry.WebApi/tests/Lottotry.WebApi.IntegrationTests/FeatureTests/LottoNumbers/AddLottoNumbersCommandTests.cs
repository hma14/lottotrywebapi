namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.LottoNumbers.Features;
    using static TestFixture;
    using System;
    using Lottotry.WebApi.Exceptions;

    public class AddLottoNumbersCommandTests : TestBase
    {
        [Test]
        public async Task AddLottoNumbersCommand_Adds_New_LottoNumbers_To_Db()
        {
            // Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbersForCreationDto { }.Generate();

            // Act
            var command = new AddLottoNumbers.AddLottoNumbersCommand(fakeLottoNumbersOne);
            var lottoNumbersReturned = await SendAsync(command);
            var lottoNumbersCreated = await ExecuteDbContextAsync(db => db.LottoNumbers.SingleOrDefaultAsync());

            // Assert
            lottoNumbersReturned.Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                options.ExcludingMissingMembers());
            lottoNumbersCreated.Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                options.ExcludingMissingMembers());
        }
    }
}
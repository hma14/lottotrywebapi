namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.LottoMax.Features;
    using static TestFixture;
    using System;
    using Lottotry.WebApi.Exceptions;

    public class AddLottoMaxCommandTests : TestBase
    {
        [Test]
        public async Task AddLottoMaxCommand_Adds_New_LottoMax_To_Db()
        {
            // Arrange
            var fakeLottoMaxOne = new FakeLottoMaxForCreationDto { }.Generate();

            // Act
            var command = new AddLottoMax.AddLottoMaxCommand(fakeLottoMaxOne);
            var lottoMaxReturned = await SendAsync(command);
            var lottoMaxCreated = await ExecuteDbContextAsync(db => db.LottoMax.SingleOrDefaultAsync());

            // Assert
            lottoMaxReturned.Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                options.ExcludingMissingMembers());
            lottoMaxCreated.Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                options.ExcludingMissingMembers());
        }
    }
}
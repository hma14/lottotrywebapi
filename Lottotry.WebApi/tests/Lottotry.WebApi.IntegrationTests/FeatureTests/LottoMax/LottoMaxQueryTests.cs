namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoMax
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.LottoMax.Features;
    using static TestFixture;

    public class LottoMaxQueryTests : TestBase
    {
        [Test]
        public async Task LottoMaxQuery_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            await InsertAsync(fakeLottoMaxOne);

            // Act
            var query = new GetLottoMax.LottoMaxQuery(fakeLottoMaxOne.DrawNumber);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxQuery_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var query = new GetLottoMax.LottoMaxQuery(badId);
            Func<Task> act = () => SendAsync(query);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
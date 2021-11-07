namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.LottoNumbers.Features;
    using static TestFixture;

    public class LottoNumbersQueryTests : TestBase
    {
        [Test]
        public async Task LottoNumbersQuery_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            await InsertAsync(fakeLottoNumbersOne);

            // Act
            var query = new GetLottoNumbers.LottoNumbersQuery(fakeLottoNumbersOne.LottoName);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersQuery_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var query = new GetLottoNumbers.LottoNumbersQuery(badId);
            Func<Task> act = () => SendAsync(query);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
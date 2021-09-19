namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.Lotto649.Features;
    using static TestFixture;

    public class Lotto649QueryTests : TestBase
    {
        [Test]
        public async Task Lotto649Query_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            await InsertAsync(fakeLotto649One);

            // Act
            var query = new GetLotto649.Lotto649Query(fakeLotto649One.DrawNumber);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().BeEquivalentTo(fakeLotto649One, options =>
                options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649Query_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var query = new GetLotto649.Lotto649Query(badId);
            Func<Task> act = () => SendAsync(query);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }
    }
}
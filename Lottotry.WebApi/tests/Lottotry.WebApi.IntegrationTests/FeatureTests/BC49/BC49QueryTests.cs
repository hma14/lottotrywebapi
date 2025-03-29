namespace Lottotry.WebApi.IntegrationTests.FeatureTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.BC49.Features;
    using static TestFixture;

    public class BC49QueryTests : TestBase
    {
        [Test]
        public async Task BC49Query_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            await InsertAsync(fakeBC49One);

            // Act
            var query = new GetBC49.BC49Query(fakeBC49One.DrawNumber);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().BeEquivalentTo(fakeBC49One, options =>
                options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49Query_Throws_KeyNotFoundException_When_Record_Does_Not_Exist()
        {
            // Arrange
            var badId = 84709321;

            // Act
            var query = new GetBC49.BC49Query(badId);
            Func<Task> act = () => SendAsync(query);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}
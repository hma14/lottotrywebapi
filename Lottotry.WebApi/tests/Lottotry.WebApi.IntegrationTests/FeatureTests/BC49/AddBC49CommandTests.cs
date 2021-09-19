namespace Lottotry.WebApi.IntegrationTests.FeatureTests.BC49
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.BC49.Features;
    using static TestFixture;
    using System;
    using Lottotry.WebApi.Exceptions;

    public class AddBC49CommandTests : TestBase
    {
        [Test]
        public async Task AddBC49Command_Adds_New_BC49_To_Db()
        {
            // Arrange
            var fakeBC49One = new FakeBC49ForCreationDto { }.Generate();

            // Act
            var command = new AddBC49.AddBC49Command(fakeBC49One);
            var bC49Returned = await SendAsync(command);
            var bC49Created = await ExecuteDbContextAsync(db => db.BC49.SingleOrDefaultAsync());

            // Assert
            bC49Returned.Should().BeEquivalentTo(fakeBC49One, options =>
                options.ExcludingMissingMembers());
            bC49Created.Should().BeEquivalentTo(fakeBC49One, options =>
                options.ExcludingMissingMembers());
        }
    }
}
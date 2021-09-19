namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Lotto649
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Lottotry.WebApi.Domain.Lotto649.Features;
    using static TestFixture;
    using System;
    using Lottotry.WebApi.Exceptions;

    public class AddLotto649CommandTests : TestBase
    {
        [Test]
        public async Task AddLotto649Command_Adds_New_Lotto649_To_Db()
        {
            // Arrange
            var fakeLotto649One = new FakeLotto649ForCreationDto { }.Generate();

            // Act
            var command = new AddLotto649.AddLotto649Command(fakeLotto649One);
            var lotto649Returned = await SendAsync(command);
            var lotto649Created = await ExecuteDbContextAsync(db => db.Lotto649.SingleOrDefaultAsync());

            // Assert
            lotto649Returned.Should().BeEquivalentTo(fakeLotto649One, options =>
                options.ExcludingMissingMembers());
            lotto649Created.Should().BeEquivalentTo(fakeLotto649One, options =>
                options.ExcludingMissingMembers());
        }
    }
}
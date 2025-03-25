namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using FluentAssertions;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Lottotry.WebApi.Domain.Numbers.Features;
using static TestFixture;
using System;

public class NumberQueryTests : TestBase
{
    [Test]
    public async Task can_get_existing_number_with_accurate_props()
    {
        // Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        await InsertAsync(fakeNumberOne);

        // Act
        var query = new GetNumber.NumberQuery(fakeNumberOne.Id);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().BeEquivalentTo(fakeNumberOne, options =>
            options.ExcludingMissingMembers());
    }

    [Test]
    public async Task get_number_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var badId = Guid.NewGuid();

        // Act
        var query = new GetNumber.NumberQuery(badId);
        Func<Task> act = () => SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}

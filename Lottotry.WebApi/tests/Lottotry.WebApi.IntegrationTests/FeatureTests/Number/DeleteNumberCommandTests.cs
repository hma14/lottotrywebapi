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

public class DeleteNumberCommandTests : TestBase
{
    [Test]
    public async Task can_delete_number_from_db()
    {
        // Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        await InsertAsync(fakeNumberOne);
        var number = await ExecuteDbContextAsync(db => db.Numbers.SingleOrDefaultAsync());
        var id = number.Id;

        // Act
        var command = new DeleteNumber.DeleteNumberCommand(id);
        await SendAsync(command);
        var numberResponse = await ExecuteDbContextAsync(db => db.Numbers.ToListAsync());

        // Assert
        numberResponse.Count.Should().Be(0);
    }

    [Test]
    public async Task delete_number_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteNumber.DeleteNumberCommand(badId);
        Func<Task> act = () => SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
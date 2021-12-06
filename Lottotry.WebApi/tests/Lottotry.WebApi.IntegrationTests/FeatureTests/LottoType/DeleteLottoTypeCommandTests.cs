namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoType;

using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.IntegrationTests.TestUtilities;
using FluentAssertions;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using Lottotry.WebApi.Domain.LottoTypes.Features;
using static TestFixture;

public class DeleteLottoTypeCommandTests : TestBase
{
    [Test]
    public async Task can_delete_lottotype_from_db()
    {
        // Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        await InsertAsync(fakeLottoTypeOne);
        var lottoType = await ExecuteDbContextAsync(db => db.LottoTypes.SingleOrDefaultAsync());
        var id = lottoType.Id;

        // Act
        var command = new DeleteLottoType.DeleteLottoTypeCommand(id);
        await SendAsync(command);
        var lottoTypeResponse = await ExecuteDbContextAsync(db => db.LottoTypes.ToListAsync());

        // Assert
        lottoTypeResponse.Count.Should().Be(0);
    }

    [Test]
    public async Task delete_lottotype_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteLottoType.DeleteLottoTypeCommand(badId);
        Func<Task> act = () => SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
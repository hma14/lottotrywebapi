namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoNumbers
{
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.IntegrationTests.TestUtilities;
    using Lottotry.WebApi.Dtos.LottoNumbers;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.JsonPatch;
    using System.Linq;
    using Lottotry.WebApi.Domain.LottoNumbers.Features;
    using static TestFixture;

    public class UpdateLottoNumbersCommandTests : TestBase
    {
        [Test]
        public async Task UpdateLottoNumbersCommand_Updates_Existing_LottoNumbers_In_Db()
        {
            // Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var updatedLottoNumbersDto = new FakeLottoNumbersForUpdateDto { }.Generate();
            await InsertAsync(fakeLottoNumbersOne);

            var lottoNumbers = await ExecuteDbContextAsync(db => db.LottoNumbers.SingleOrDefaultAsync());
            var lottoName = lottoNumbers.LottoName;

            // Act
            var command = new UpdateLottoNumbers.UpdateLottoNumbersCommand(lottoName, updatedLottoNumbersDto);
            await SendAsync(command);
            var updatedLottoNumbers = await ExecuteDbContextAsync(db => db.LottoNumbers.Where(l => l.LottoName == lottoName).SingleOrDefaultAsync());

            // Assert
            updatedLottoNumbers.Should().BeEquivalentTo(updatedLottoNumbersDto, options =>
                options.ExcludingMissingMembers());
        }
    }
}
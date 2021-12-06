namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoType;

using Lottotry.WebApi.Dtos.LottoType;
using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;
using Lottotry.WebApi.Exceptions;
using Lottotry.WebApi.Domain.LottoTypes.Features;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using static TestFixture;

public class LottoTypeListQueryTests : TestBase
{
    
    [Test]
    public async Task can_get_lottotype_list()
    {
        // Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        var queryParameters = new LottoTypeParametersDto();

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        // Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().HaveCount(2);
    }
    
    [Test]
    public async Task can_get_lottotype_list_with_expected_page_size_and_number()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        var fakeLottoTypeThree = new FakeLottoType { }.Generate();
        var queryParameters = new LottoTypeParametersDto() { PageSize = 1, PageNumber = 2 };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo, fakeLottoTypeThree);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().HaveCount(1);
    }
    
    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_LottoName_in_asc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.LottoName = 2;
        fakeLottoTypeTwo.LottoName = 1;
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "LottoName" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_LottoName_in_desc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.LottoName = 1;
        fakeLottoTypeTwo.LottoName = 2;
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "-LottoName" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_DrawNumber_in_asc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.DrawNumber = 2;
        fakeLottoTypeTwo.DrawNumber = 1;
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "DrawNumber" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_DrawNumber_in_desc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.DrawNumber = 1;
        fakeLottoTypeTwo.DrawNumber = 2;
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "-DrawNumber" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_DrawDate_in_asc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.DrawDate = DateTime.Now.AddDays(2);
        fakeLottoTypeTwo.DrawDate = DateTime.Now.AddDays(1);
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "DrawDate" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_DrawDate_in_desc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.DrawDate = DateTime.Now.AddDays(1);
        fakeLottoTypeTwo.DrawDate = DateTime.Now.AddDays(2);
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "-DrawDate" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_NumberRange_in_asc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.NumberRange = 2;
        fakeLottoTypeTwo.NumberRange = 1;
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "NumberRange" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_lottotype_by_NumberRange_in_desc_order()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.NumberRange = 1;
        fakeLottoTypeTwo.NumberRange = 2;
        var queryParameters = new LottoTypeParametersDto() { SortOrder = "-NumberRange" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
        lottoTypes
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeOne, options =>
                options.ExcludingMissingMembers());
    }

    
    [Test]
    public async Task can_filter_lottotype_list_using_LottoName()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.LottoName = 1;
        fakeLottoTypeTwo.LottoName = 2;
        var queryParameters = new LottoTypeParametersDto() { Filters = $"LottoName == {fakeLottoTypeTwo.LottoName}" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().HaveCount(1);
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_lottotype_list_using_DrawNumber()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.DrawNumber = 1;
        fakeLottoTypeTwo.DrawNumber = 2;
        var queryParameters = new LottoTypeParametersDto() { Filters = $"DrawNumber == {fakeLottoTypeTwo.DrawNumber}" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().HaveCount(1);
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_lottotype_list_using_DrawDate()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.DrawDate = DateTime.Now.AddDays(1);
        fakeLottoTypeTwo.DrawDate = DateTime.Parse(DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
        var queryParameters = new LottoTypeParametersDto() { Filters = $"DrawDate == {fakeLottoTypeTwo.DrawDate}" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().HaveCount(1);
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_lottotype_list_using_NumberRange()
    {
        //Arrange
        var fakeLottoTypeOne = new FakeLottoType { }.Generate();
        var fakeLottoTypeTwo = new FakeLottoType { }.Generate();
        fakeLottoTypeOne.NumberRange = 1;
        fakeLottoTypeTwo.NumberRange = 2;
        var queryParameters = new LottoTypeParametersDto() { Filters = $"NumberRange == {fakeLottoTypeTwo.NumberRange}" };

        await InsertAsync(fakeLottoTypeOne, fakeLottoTypeTwo);

        //Act
        var query = new GetLottoTypeList.LottoTypeListQuery(queryParameters);
        var lottoTypes = await SendAsync(query);

        // Assert
        lottoTypes.Should().HaveCount(1);
        lottoTypes
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeLottoTypeTwo, options =>
                options.ExcludingMissingMembers());
    }

}
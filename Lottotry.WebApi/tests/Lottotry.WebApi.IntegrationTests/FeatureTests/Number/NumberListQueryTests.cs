namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Number;

using Lottotry.WebApi.Dtos.Number;
using Lottotry.WebApi.SharedTestHelpers.Fakes.Number;
using Lottotry.WebApi.Exceptions;
using Lottotry.WebApi.Domain.Numbers.Features;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using static TestFixture;
using System.Linq;
using System;

public class NumberListQueryTests : TestBase
{
    
    [Test]
    public async Task can_get_number_list()
    {
        // Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        var queryParameters = new NumberParametersDto();

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        // Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(2);
    }
    
    [Test]
    public async Task can_get_number_list_with_expected_page_size_and_number()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        var fakeNumberThree = new FakeNumber { }.Generate();
        var queryParameters = new NumberParametersDto() { PageSize = 1, PageNumber = 2 };

        await InsertAsync(fakeNumberOne, fakeNumberTwo, fakeNumberThree);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
    }
    
    [Test]
    public async Task can_get_sorted_list_of_number_by_Id_in_asc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Id = Guid.NewGuid();
        fakeNumberTwo.Id = Guid.NewGuid();
        var queryParameters = new NumberParametersDto() { SortOrder = "Id" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_Id_in_desc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Id = Guid.NewGuid();
        fakeNumberTwo.Id = Guid.NewGuid();
        var queryParameters = new NumberParametersDto() { SortOrder = "-Id" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_Value_in_asc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Value = 2;
        fakeNumberTwo.Value = 1;
        var queryParameters = new NumberParametersDto() { SortOrder = "Value" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_Value_in_desc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Value = 1;
        fakeNumberTwo.Value = 2;
        var queryParameters = new NumberParametersDto() { SortOrder = "-Value" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_Distance_in_asc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Distance = 2;
        fakeNumberTwo.Distance = 1;
        var queryParameters = new NumberParametersDto() { SortOrder = "Distance" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_Distance_in_desc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Distance = 1;
        fakeNumberTwo.Distance = 2;
        var queryParameters = new NumberParametersDto() { SortOrder = "-Distance" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_NumberofDrawsWhenHit_in_asc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.NumberofDrawsWhenHit = 2;
        fakeNumberTwo.NumberofDrawsWhenHit = 1;
        var queryParameters = new NumberParametersDto() { SortOrder = "NumberofDrawsWhenHit" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_get_sorted_list_of_number_by_NumberofDrawsWhenHit_in_desc_order()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.NumberofDrawsWhenHit = 1;
        fakeNumberTwo.NumberofDrawsWhenHit = 2;
        var queryParameters = new NumberParametersDto() { SortOrder = "-NumberofDrawsWhenHit" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
        numbers
            .Skip(1)
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberOne, options =>
                options.ExcludingMissingMembers());
    }

    
    [Test]
    public async Task can_filter_number_list_using_Id()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Id = Guid.NewGuid();
        fakeNumberTwo.Id = Guid.NewGuid();
        var queryParameters = new NumberParametersDto() { Filters = $"Id == {fakeNumberTwo.Id}" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_number_list_using_Value()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Value = 1;
        fakeNumberTwo.Value = 2;
        var queryParameters = new NumberParametersDto() { Filters = $"Value == {fakeNumberTwo.Value}" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_number_list_using_Distance()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.Distance = 1;
        fakeNumberTwo.Distance = 2;
        var queryParameters = new NumberParametersDto() { Filters = $"Distance == {fakeNumberTwo.Distance}" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_number_list_using_IsHit()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.IsHit = false;
        fakeNumberTwo.IsHit = true;
        var queryParameters = new NumberParametersDto() { Filters = $"IsHit == {fakeNumberTwo.IsHit}" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_number_list_using_NumberofDrawsWhenHit()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.NumberofDrawsWhenHit = 1;
        fakeNumberTwo.NumberofDrawsWhenHit = 2;
        var queryParameters = new NumberParametersDto() { Filters = $"NumberofDrawsWhenHit == {fakeNumberTwo.NumberofDrawsWhenHit}" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
    }

    [Test]
    public async Task can_filter_number_list_using_IsBonusNumber()
    {
        //Arrange
        var fakeNumberOne = new FakeNumber { }.Generate();
        var fakeNumberTwo = new FakeNumber { }.Generate();
        fakeNumberOne.IsBonusNumber = false;
        fakeNumberTwo.IsBonusNumber = true;
        var queryParameters = new NumberParametersDto() { Filters = $"IsBonusNumber == {fakeNumberTwo.IsBonusNumber}" };

        await InsertAsync(fakeNumberOne, fakeNumberTwo);

        //Act
        var query = new GetNumberList.NumberListQuery(queryParameters);
        var numbers = await SendAsync(query);

        // Assert
        numbers.Should().HaveCount(1);
        numbers
            .FirstOrDefault()
            .Should().BeEquivalentTo(fakeNumberTwo, options =>
                options.ExcludingMissingMembers());
    }

}
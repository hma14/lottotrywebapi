namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoNumbers
{
    using Lottotry.WebApi.Dtos.LottoNumbers;
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoNumbers;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Domain.LottoNumbers.Features;
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static TestFixture;

    public class LottoNumbersListQueryTests : TestBase
    {
        
        [Test]
        public async Task LottoNumbersListQuery_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            var queryParameters = new LottoNumbersParametersDto();

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            // Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(2);
        }
        
        [Test]
        public async Task LottoNumbersListQuery_Returns_Expected_Page_Size_And_Number()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersThree = new FakeLottoNumbers { }.Generate();
            var queryParameters = new LottoNumbersParametersDto() { PageSize = 1, PageNumber = 2 };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo, fakeLottoNumbersThree);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
        }
        
        [Test]
        public async Task LottoNumbersListQuery_Throws_ApiException_When_Null_Query_Parameters()
        {
            // Arrange
            // N/A

            // Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(null);
            Func<Task> act = () => SendAsync(query);

            // Assert
            act.Should().Throw<ApiException>();
        }
        
        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_LottoName_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.LottoName = 2;
            fakeLottoNumbersTwo.LottoName = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "LottoName" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_LottoName_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.LottoName = 2;
            fakeLottoNumbersTwo.LottoName = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "LottoName" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_DrawNumber_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.DrawNumber = 2;
            fakeLottoNumbersTwo.DrawNumber = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "DrawNumber" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_DrawNumber_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.DrawNumber = 2;
            fakeLottoNumbersTwo.DrawNumber = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "DrawNumber" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_DrawDate_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.DrawDate = DateTime.Now.AddDays(2);
            fakeLottoNumbersTwo.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_DrawDate_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.DrawDate = DateTime.Now.AddDays(2);
            fakeLottoNumbersTwo.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_Number_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.Number = 2;
            fakeLottoNumbersTwo.Number = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "Number" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_Number_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.Number = 2;
            fakeLottoNumbersTwo.Number = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "Number" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_NumberRange_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.NumberRange = 2;
            fakeLottoNumbersTwo.NumberRange = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "NumberRange" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_NumberRange_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.NumberRange = 2;
            fakeLottoNumbersTwo.NumberRange = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "NumberRange" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_Distance_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.Distance = 2;
            fakeLottoNumbersTwo.Distance = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "Distance" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_Distance_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.Distance = 2;
            fakeLottoNumbersTwo.Distance = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "Distance" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_NumberofDrawsWhenHit_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.NumberofDrawsWhenHit = 2;
            fakeLottoNumbersTwo.NumberofDrawsWhenHit = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "NumberofDrawsWhenHit" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Returns_Sorted_LottoNumbers_NumberofDrawsWhenHit_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.NumberofDrawsWhenHit = 2;
            fakeLottoNumbersTwo.NumberofDrawsWhenHit = 1;
            var queryParameters = new LottoNumbersParametersDto() { SortOrder = "NumberofDrawsWhenHit" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
            lottoNumbers
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersOne, options =>
                    options.ExcludingMissingMembers());
        }

        
        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_LottoName()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.LottoName = 1;
            fakeLottoNumbersTwo.LottoName = 2;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"LottoName == {fakeLottoNumbersTwo.LottoName}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_DrawNumber()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.DrawNumber = 1;
            fakeLottoNumbersTwo.DrawNumber = 2;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"DrawNumber == {fakeLottoNumbersTwo.DrawNumber}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_DrawDate()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.DrawDate = DateTime.Now.AddDays(1);
            fakeLottoNumbersTwo.DrawDate = DateTime.Parse(DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"DrawDate == {fakeLottoNumbersTwo.DrawDate}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_Number()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.Number = 1;
            fakeLottoNumbersTwo.Number = 2;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"Number == {fakeLottoNumbersTwo.Number}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_NumberRange()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.NumberRange = 1;
            fakeLottoNumbersTwo.NumberRange = 2;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"NumberRange == {fakeLottoNumbersTwo.NumberRange}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_Distance()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.Distance = 1;
            fakeLottoNumbersTwo.Distance = 2;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"Distance == {fakeLottoNumbersTwo.Distance}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_IsHit()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.IsHit = false;
            fakeLottoNumbersTwo.IsHit = true;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"IsHit == {fakeLottoNumbersTwo.IsHit}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_NumberofDrawsWhenHit()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.NumberofDrawsWhenHit = 1;
            fakeLottoNumbersTwo.NumberofDrawsWhenHit = 2;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"NumberofDrawsWhenHit == {fakeLottoNumbersTwo.NumberofDrawsWhenHit}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoNumbersListQuery_Filters_LottoNumbers_IsBonusNumber()
        {
            //Arrange
            var fakeLottoNumbersOne = new FakeLottoNumbers { }.Generate();
            var fakeLottoNumbersTwo = new FakeLottoNumbers { }.Generate();
            fakeLottoNumbersOne.IsBonusNumber = false;
            fakeLottoNumbersTwo.IsBonusNumber = true;
            var queryParameters = new LottoNumbersParametersDto() { Filters = $"IsBonusNumber == {fakeLottoNumbersTwo.IsBonusNumber}" };

            await InsertAsync(fakeLottoNumbersOne, fakeLottoNumbersTwo);

            //Act
            var query = new GetLottoNumbersList.LottoNumbersListQuery(queryParameters);
            var lottoNumbers = await SendAsync(query);

            // Assert
            lottoNumbers.Should().HaveCount(1);
            lottoNumbers
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoNumbersTwo, options =>
                    options.ExcludingMissingMembers());
        }

    }
}
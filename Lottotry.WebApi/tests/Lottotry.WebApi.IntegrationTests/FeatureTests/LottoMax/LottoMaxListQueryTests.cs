namespace Lottotry.WebApi.IntegrationTests.FeatureTests.LottoMax
{
    using Lottotry.WebApi.Dtos.LottoMax;
    using Lottotry.WebApi.SharedTestHelpers.Fakes.LottoMax;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Domain.LottoMax.Features;
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static TestFixture;

    public class LottoMaxListQueryTests : TestBase
    {
        
        [Test]
        public async Task LottoMaxListQuery_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            var queryParameters = new LottoMaxParametersDto();

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            // Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(2);
        }
        
        [Test]
        public async Task LottoMaxListQuery_Returns_Expected_Page_Size_And_Number()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            var fakeLottoMaxThree = new FakeLottoMax { }.Generate();
            var queryParameters = new LottoMaxParametersDto() { PageSize = 1, PageNumber = 2 };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo, fakeLottoMaxThree);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
        }
        
        [Test]
        public async Task LottoMaxListQuery_Throws_ApiException_When_Null_Query_Parameters()
        {
            // Arrange
            // N/A

            // Act
            var query = new GetLottoMaxList.LottoMaxListQuery(null);
            Func<Task> act = () => SendAsync(query);

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }
        
        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_DrawDate_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.DrawDate = DateTime.Now.AddDays(2);
            fakeLottoMaxTwo.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_DrawDate_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.DrawDate = DateTime.Now.AddDays(2);
            fakeLottoMaxTwo.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number1_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number1 = 2;
            fakeLottoMaxTwo.Number1 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number1" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number1_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number1 = 2;
            fakeLottoMaxTwo.Number1 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number1" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number2_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number2 = 2;
            fakeLottoMaxTwo.Number2 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number2" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number2_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number2 = 2;
            fakeLottoMaxTwo.Number2 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number2" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number3_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number3 = 2;
            fakeLottoMaxTwo.Number3 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number3" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number3_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number3 = 2;
            fakeLottoMaxTwo.Number3 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number3" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number4_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number4 = 2;
            fakeLottoMaxTwo.Number4 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number4" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number4_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number4 = 2;
            fakeLottoMaxTwo.Number4 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number4" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number5_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number5 = 2;
            fakeLottoMaxTwo.Number5 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number5" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number5_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number5 = 2;
            fakeLottoMaxTwo.Number5 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number5" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number6_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number6 = 2;
            fakeLottoMaxTwo.Number6 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number6" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number6_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number6 = 2;
            fakeLottoMaxTwo.Number6 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number6" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number7_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number7 = 2;
            fakeLottoMaxTwo.Number7 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number7" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Number7_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number7 = 2;
            fakeLottoMaxTwo.Number7 = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Number7" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Bonus_List_In_Asc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Bonus = 2;
            fakeLottoMaxTwo.Bonus = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Bonus" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Returns_Sorted_LottoMax_Bonus_List_In_Desc_Order()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Bonus = 2;
            fakeLottoMaxTwo.Bonus = 1;
            var queryParameters = new LottoMaxParametersDto() { SortOrder = "Bonus" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
            lottoMax
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxOne, options =>
                    options.ExcludingMissingMembers());
        }

        
        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_DrawNumber()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.DrawNumber = 1;
            fakeLottoMaxTwo.DrawNumber = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"DrawNumber == {fakeLottoMaxTwo.DrawNumber}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_DrawDate()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.DrawDate = DateTime.Now.AddDays(1);
            fakeLottoMaxTwo.DrawDate = DateTime.Parse(DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
            var queryParameters = new LottoMaxParametersDto() { Filters = $"DrawDate == {fakeLottoMaxTwo.DrawDate}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number1()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number1 = 1;
            fakeLottoMaxTwo.Number1 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number1 == {fakeLottoMaxTwo.Number1}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number2()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number2 = 1;
            fakeLottoMaxTwo.Number2 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number2 == {fakeLottoMaxTwo.Number2}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number3()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number3 = 1;
            fakeLottoMaxTwo.Number3 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number3 == {fakeLottoMaxTwo.Number3}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number4()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number4 = 1;
            fakeLottoMaxTwo.Number4 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number4 == {fakeLottoMaxTwo.Number4}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number5()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number5 = 1;
            fakeLottoMaxTwo.Number5 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number5 == {fakeLottoMaxTwo.Number5}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number6()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number6 = 1;
            fakeLottoMaxTwo.Number6 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number6 == {fakeLottoMaxTwo.Number6}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Number7()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Number7 = 1;
            fakeLottoMaxTwo.Number7 = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Number7 == {fakeLottoMaxTwo.Number7}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task LottoMaxListQuery_Filters_LottoMax_Bonus()
        {
            //Arrange
            var fakeLottoMaxOne = new FakeLottoMax { }.Generate();
            var fakeLottoMaxTwo = new FakeLottoMax { }.Generate();
            fakeLottoMaxOne.Bonus = 1;
            fakeLottoMaxTwo.Bonus = 2;
            var queryParameters = new LottoMaxParametersDto() { Filters = $"Bonus == {fakeLottoMaxTwo.Bonus}" };

            await InsertAsync(fakeLottoMaxOne, fakeLottoMaxTwo);

            //Act
            var query = new GetLottoMaxList.LottoMaxListQuery(queryParameters);
            var lottoMax = await SendAsync(query);

            // Assert
            lottoMax.Should().HaveCount(1);
            lottoMax
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLottoMaxTwo, options =>
                    options.ExcludingMissingMembers());
        }

    }
}
namespace Lottotry.WebApi.IntegrationTests.FeatureTests.Lotto649
{
    using Lottotry.WebApi.Dtos.Lotto649;
    using Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Domain.Lotto649.Features;
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static TestFixture;

    public class Lotto649ListQueryTests : TestBase
    {
        
        [Test]
        public async Task Lotto649ListQuery_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            var queryParameters = new Lotto649ParametersDto();

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            // Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(2);
        }
        
        [Test]
        public async Task Lotto649ListQuery_Returns_Expected_Page_Size_And_Number()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            var fakeLotto649Three = new FakeLotto649 { }.Generate();
            var queryParameters = new Lotto649ParametersDto() { PageSize = 1, PageNumber = 2 };

            await InsertAsync(fakeLotto649One, fakeLotto649Two, fakeLotto649Three);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
        }
        
        [Test]
        public async Task Lotto649ListQuery_Throws_ApiException_When_Null_Query_Parameters()
        {
            // Arrange
            // N/A

            // Act
            var query = new GetLotto649List.Lotto649ListQuery(null);
            Func<Task> act = () => SendAsync(query);

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }
        
        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_DrawDate_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.DrawDate = DateTime.Now.AddDays(2);
            fakeLotto649Two.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_DrawDate_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.DrawDate = DateTime.Now.AddDays(2);
            fakeLotto649Two.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number1_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number1 = 2;
            fakeLotto649Two.Number1 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number1" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number1_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number1 = 2;
            fakeLotto649Two.Number1 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number1" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number2_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number2 = 2;
            fakeLotto649Two.Number2 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number2" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number2_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number2 = 2;
            fakeLotto649Two.Number2 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number2" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number3_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number3 = 2;
            fakeLotto649Two.Number3 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number3" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number3_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number3 = 2;
            fakeLotto649Two.Number3 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number3" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number4_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number4 = 2;
            fakeLotto649Two.Number4 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number4" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number4_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number4 = 2;
            fakeLotto649Two.Number4 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number4" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number5_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number5 = 2;
            fakeLotto649Two.Number5 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number5" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number5_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number5 = 2;
            fakeLotto649Two.Number5 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number5" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number6_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number6 = 2;
            fakeLotto649Two.Number6 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number6" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Number6_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number6 = 2;
            fakeLotto649Two.Number6 = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Number6" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Bonus_List_In_Asc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Bonus = 2;
            fakeLotto649Two.Bonus = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Bonus" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Returns_Sorted_Lotto649_Bonus_List_In_Desc_Order()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Bonus = 2;
            fakeLotto649Two.Bonus = 1;
            var queryParameters = new Lotto649ParametersDto() { SortOrder = "Bonus" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
            lotto649
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649One, options =>
                    options.ExcludingMissingMembers());
        }

        
        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_DrawNumber()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.DrawNumber = 1;
            fakeLotto649Two.DrawNumber = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"DrawNumber == {fakeLotto649Two.DrawNumber}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_DrawDate()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.DrawDate = DateTime.Now.AddDays(1);
            fakeLotto649Two.DrawDate = DateTime.Parse(DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
            var queryParameters = new Lotto649ParametersDto() { Filters = $"DrawDate == {fakeLotto649Two.DrawDate}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Number1()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number1 = 1;
            fakeLotto649Two.Number1 = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Number1 == {fakeLotto649Two.Number1}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Number2()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number2 = 1;
            fakeLotto649Two.Number2 = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Number2 == {fakeLotto649Two.Number2}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Number3()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number3 = 1;
            fakeLotto649Two.Number3 = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Number3 == {fakeLotto649Two.Number3}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Number4()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number4 = 1;
            fakeLotto649Two.Number4 = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Number4 == {fakeLotto649Two.Number4}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Number5()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number5 = 1;
            fakeLotto649Two.Number5 = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Number5 == {fakeLotto649Two.Number5}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Number6()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Number6 = 1;
            fakeLotto649Two.Number6 = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Number6 == {fakeLotto649Two.Number6}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task Lotto649ListQuery_Filters_Lotto649_Bonus()
        {
            //Arrange
            var fakeLotto649One = new FakeLotto649 { }.Generate();
            var fakeLotto649Two = new FakeLotto649 { }.Generate();
            fakeLotto649One.Bonus = 1;
            fakeLotto649Two.Bonus = 2;
            var queryParameters = new Lotto649ParametersDto() { Filters = $"Bonus == {fakeLotto649Two.Bonus}" };

            await InsertAsync(fakeLotto649One, fakeLotto649Two);

            //Act
            var query = new GetLotto649List.Lotto649ListQuery(queryParameters);
            var lotto649 = await SendAsync(query);

            // Assert
            lotto649.Should().HaveCount(1);
            lotto649
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeLotto649Two, options =>
                    options.ExcludingMissingMembers());
        }

    }
}
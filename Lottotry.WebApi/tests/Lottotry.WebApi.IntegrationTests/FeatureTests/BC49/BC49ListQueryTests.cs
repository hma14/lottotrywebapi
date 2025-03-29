namespace Lottotry.WebApi.IntegrationTests.FeatureTests.BC49
{
    using Lottotry.WebApi.Dtos.BC49;
    using Lottotry.WebApi.SharedTestHelpers.Fakes.BC49;
    using Lottotry.WebApi.Exceptions;
    using Lottotry.WebApi.Domain.BC49.Features;
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static TestFixture;

    public class BC49ListQueryTests : TestBase
    {
        
        [Test]
        public async Task BC49ListQuery_Returns_Resource_With_Accurate_Props()
        {
            // Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            var queryParameters = new BC49ParametersDto();

            await InsertAsync(fakeBC49One, fakeBC49Two);

            // Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(2);
        }
        
        [Test]
        public async Task BC49ListQuery_Returns_Expected_Page_Size_And_Number()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            var fakeBC49Three = new FakeBC49 { }.Generate();
            var queryParameters = new BC49ParametersDto() { PageSize = 1, PageNumber = 2 };

            await InsertAsync(fakeBC49One, fakeBC49Two, fakeBC49Three);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
        }
        
        [Test]
        public async Task BC49ListQuery_Throws_ApiException_When_Null_Query_Parameters()
        {
            // Arrange
            // N/A

            // Act
            var query = new GetBC49List.BC49ListQuery(null);
            Func<Task> act = () => SendAsync(query);

            // Assert
            await act.Should().ThrowAsync<ApiException>();
        }
        
        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_DrawDate_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.DrawDate = DateTime.Now.AddDays(2);
            fakeBC49Two.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new BC49ParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_DrawDate_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.DrawDate = DateTime.Now.AddDays(2);
            fakeBC49Two.DrawDate = DateTime.Now.AddDays(1);
            var queryParameters = new BC49ParametersDto() { SortOrder = "DrawDate" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number1_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number1 = 2;
            fakeBC49Two.Number1 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number1" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number1_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number1 = 2;
            fakeBC49Two.Number1 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number1" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number2_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number2 = 2;
            fakeBC49Two.Number2 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number2" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number2_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number2 = 2;
            fakeBC49Two.Number2 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number2" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number3_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number3 = 2;
            fakeBC49Two.Number3 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number3" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number3_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number3 = 2;
            fakeBC49Two.Number3 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number3" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number4_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number4 = 2;
            fakeBC49Two.Number4 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number4" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number4_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number4 = 2;
            fakeBC49Two.Number4 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number4" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number5_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number5 = 2;
            fakeBC49Two.Number5 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number5" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number5_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number5 = 2;
            fakeBC49Two.Number5 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number5" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number6_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number6 = 2;
            fakeBC49Two.Number6 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number6" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Number6_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number6 = 2;
            fakeBC49Two.Number6 = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Number6" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Bonus_List_In_Asc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Bonus = 2;
            fakeBC49Two.Bonus = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Bonus" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Returns_Sorted_BC49_Bonus_List_In_Desc_Order()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Bonus = 2;
            fakeBC49Two.Bonus = 1;
            var queryParameters = new BC49ParametersDto() { SortOrder = "Bonus" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
            bC49
                .Skip(1)
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49One, options =>
                    options.ExcludingMissingMembers());
        }

        
        [Test]
        public async Task BC49ListQuery_Filters_BC49_DrawNumber()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.DrawNumber = 1;
            fakeBC49Two.DrawNumber = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"DrawNumber == {fakeBC49Two.DrawNumber}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_DrawDate()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.DrawDate = DateTime.Now.AddDays(1);
            fakeBC49Two.DrawDate = DateTime.Parse(DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
            var queryParameters = new BC49ParametersDto() { Filters = $"DrawDate == {fakeBC49Two.DrawDate}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Number1()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number1 = 1;
            fakeBC49Two.Number1 = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Number1 == {fakeBC49Two.Number1}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Number2()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number2 = 1;
            fakeBC49Two.Number2 = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Number2 == {fakeBC49Two.Number2}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Number3()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number3 = 1;
            fakeBC49Two.Number3 = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Number3 == {fakeBC49Two.Number3}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Number4()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number4 = 1;
            fakeBC49Two.Number4 = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Number4 == {fakeBC49Two.Number4}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Number5()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number5 = 1;
            fakeBC49Two.Number5 = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Number5 == {fakeBC49Two.Number5}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Number6()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Number6 = 1;
            fakeBC49Two.Number6 = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Number6 == {fakeBC49Two.Number6}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

        [Test]
        public async Task BC49ListQuery_Filters_BC49_Bonus()
        {
            //Arrange
            var fakeBC49One = new FakeBC49 { }.Generate();
            var fakeBC49Two = new FakeBC49 { }.Generate();
            fakeBC49One.Bonus = 1;
            fakeBC49Two.Bonus = 2;
            var queryParameters = new BC49ParametersDto() { Filters = $"Bonus == {fakeBC49Two.Bonus}" };

            await InsertAsync(fakeBC49One, fakeBC49Two);

            //Act
            var query = new GetBC49List.BC49ListQuery(queryParameters);
            var bC49 = await SendAsync(query);

            // Assert
            bC49.Should().HaveCount(1);
            bC49
                .FirstOrDefault()
                .Should().BeEquivalentTo(fakeBC49Two, options =>
                    options.ExcludingMissingMembers());
        }

    }
}
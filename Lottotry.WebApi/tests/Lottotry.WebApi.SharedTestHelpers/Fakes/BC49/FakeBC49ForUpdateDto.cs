namespace Lottotry.WebApi.SharedTestHelpers.Fakes.BC49
{
    using AutoBogus;
    using Lottotry.WebApi.Dtos.BC49;
    using System;

    // or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
    public class FakeBC49ForUpdateDto : AutoFaker<BC49ForUpdateDto>
    {
        public FakeBC49ForUpdateDto()
        {
            // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
            RuleFor(b => b.Number1, b => b.Random.Number(1, 10));
            RuleFor(b => b.Number2, b => b.Random.Number(10, 20));
            RuleFor(b => b.Number3, b => b.Random.Number(20, 30));
            RuleFor(b => b.Number4, b => b.Random.Number(30, 40));
            RuleFor(b => b.Number5, b => b.Random.Number(40, 49));
            RuleFor(b => b.Number6, b => 49);
            RuleFor(b => b.Bonus, b => 5);
            RuleFor(b => b.DrawDate, f => f.Date.Past(0, DateTime.Now.AddDays(-7)));
        }
    }
}
namespace Lottotry.WebApi.SharedTestHelpers.Fakes.BC49
{
    using AutoBogus;
    using Lottotry.WebApi.Domain.BC49;

    // or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
    public class FakeBC49 : AutoFaker<BC49>
    {
        public FakeBC49()
        {
            // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
            //RuleFor(b => b.ExampleIntProperty, b => b.Random.Number(50, 100000));
            //RuleFor(b => b.ExampleDateProperty, b => b.Date.Past());
        }
    }
}
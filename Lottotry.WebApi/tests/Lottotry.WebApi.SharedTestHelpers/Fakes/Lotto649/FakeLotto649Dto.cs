namespace Lottotry.WebApi.SharedTestHelpers.Fakes.Lotto649
{
    using AutoBogus;
    using Lottotry.WebApi.Dtos.Lotto649;

    // or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
    public class FakeLotto649Dto : AutoFaker<Lotto649Dto>
    {
        public FakeLotto649Dto()
        {
            // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
            //RuleFor(l => l.ExampleIntProperty, l => l.Random.Number(50, 100000));
            //RuleFor(l => l.ExampleDateProperty, l => l.Date.Past());
        }
    }
}
namespace Lottotry.WebApi.SharedTestHelpers.Fakes.Number;

using AutoBogus;
using Lottotry.WebApi.Domain.Numbers;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public class FakeNumber : AutoFaker<Number>
{
    public FakeNumber()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(n => n.ExampleIntProperty, n => n.Random.Number(50, 100000));
        //RuleFor(n => n.ExampleDateProperty, n => n.Date.Past());
    }
}
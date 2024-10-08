namespace Lottotry.WebApi.SharedTestHelpers.Fakes.DailyGrand_GrandNumber;

using AutoBogus;
using Lottotry.WebApi.Dtos.DailyGrand_GrandNumber;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public class FakeDailyGrand_GrandNumberForUpdateDto : AutoFaker<DailyGrand_GrandNumberForUpdateDto>
{
    public FakeDailyGrand_GrandNumberForUpdateDto()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(d => d.ExampleIntProperty, d => d.Random.Number(50, 100000));
        //RuleFor(d => d.ExampleDateProperty, d => d.Date.Past());
    }
}
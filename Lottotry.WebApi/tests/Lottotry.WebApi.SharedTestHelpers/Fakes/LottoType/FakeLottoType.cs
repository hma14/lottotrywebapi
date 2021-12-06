namespace Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;

using AutoBogus;
using Lottotry.WebApi.Domain.LottoTypes;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public class FakeLottoType : AutoFaker<LottoType>
{
    public FakeLottoType()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(l => l.ExampleIntProperty, l => l.Random.Number(50, 100000));
        //RuleFor(l => l.ExampleDateProperty, l => l.Date.Past());
    }
}
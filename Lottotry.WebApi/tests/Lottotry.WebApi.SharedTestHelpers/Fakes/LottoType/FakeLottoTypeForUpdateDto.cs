namespace Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;

using AutoBogus;
using Lottotry.WebApi.Dtos.LottoType;
using System;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public class FakeLottoTypeForUpdateDto : AutoFaker<LottoTypeForUpdateDto>
{
    public FakeLottoTypeForUpdateDto()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(l => l.ExampleIntProperty, l => l.Random.Number(50, 100000));
        //RuleFor(l => l.ExampleDateProperty, l => l.Date.Past());


        RuleFor(l => l.LottoName, l => 1);
        RuleFor(l => l.DrawNumber, l => 101);
        RuleFor(l => l.NumberRange, l => 49);
        RuleFor(b => b.DrawDate, f => f.Date.Past(0, DateTime.Now.AddDays(-7)));
    }
}
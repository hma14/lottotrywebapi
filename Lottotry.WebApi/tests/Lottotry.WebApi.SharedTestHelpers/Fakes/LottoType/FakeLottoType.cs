namespace Lottotry.WebApi.SharedTestHelpers.Fakes.LottoType;

using AutoBogus;
using Lottotry.WebApi.Domain.LottoTypes;
using System;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public class FakeLottoType : AutoFaker<LottoType>
{
    public FakeLottoType()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(l => l.ExampleIntProperty, l => l.Random.Number(50, 100000));
        //RuleFor(l => l.ExampleDateProperty, l => l.Date.Past());

        RuleFor(b => b.Id, b => Guid.NewGuid());
        RuleFor(b => b.LottoName, b => 1);
        RuleFor(b => b.DrawNumber, b => b.Random.Number(1, 1000));
        RuleFor(b => b.DrawDate, f => f.Date.Past(0, DateTime.Now.AddDays(-7)));
        RuleFor(b => b.NumberRange, b => 49);
    }
}
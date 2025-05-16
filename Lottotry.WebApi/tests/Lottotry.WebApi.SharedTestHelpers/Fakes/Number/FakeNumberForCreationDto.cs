namespace Lottotry.WebApi.SharedTestHelpers.Fakes.Number;

using AutoBogus;
using Lottotry.WebApi.Dtos.Number;
using System;

// or replace 'AutoFaker' with 'Faker' along with your own rules if you don't want all fields to be auto faked
public class FakeNumberForCreationDto : AutoFaker<NumberForCreationDto>
{
    public FakeNumberForCreationDto()
    {
        // if you want default values on any of your properties (e.g. an int between a certain range or a date always in the past), you can add `RuleFor` lines describing those defaults
        //RuleFor(n => n.ExampleIntProperty, n => n.Random.Number(50, 100000));
        //RuleFor(n => n.ExampleDateProperty, n => n.Date.Past());

        RuleFor(b => b.Id, b => Guid.NewGuid());
        RuleFor(b => b.Value, b => b.Random.Number(1, 49));
        RuleFor(b => b.Distance, b => b.Random.Number(1, 10));
        RuleFor(b => b.IsHit, b => false);
        RuleFor(b => b.NumberofDrawsWhenHit, b => b.Random.Number(1, 10));
        RuleFor(b => b.IsBonusNumber, b => false);
        //RuleFor(b => b.LottoTypeId, b => Guid.NewGuid());
    }
}
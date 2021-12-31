namespace Lottotry.WebApi.Domain.DailyGrand_GrandNumber.Validators
{

    using Lottotry.WebApi.Dtos.DailyGrand_GrandNumber;
    using FluentValidation;

    public class DailyGrand_GrandNumberForCreationDtoValidator : DailyGrand_GrandNumberForManipulationDtoValidator<DailyGrand_GrandNumberForCreationDto>
    {
        public DailyGrand_GrandNumberForCreationDtoValidator()
        {
            // add fluent validation rules that should only be run on creation operations here
            //https://fluentvalidation.net/
        }
    }
}
namespace Lottotry.WebApi.Domain.DailyGrand_GrandNumber.Validators
{

    using Lottotry.WebApi.Dtos.DailyGrand_GrandNumber;
    using FluentValidation;

    public class DailyGrand_GrandNumberForUpdateDtoValidator : DailyGrand_GrandNumberForManipulationDtoValidator<DailyGrand_GrandNumberForUpdateDto>
    {
        public DailyGrand_GrandNumberForUpdateDtoValidator()
        {
            // add fluent validation rules that should only be run on update operations here
            //https://fluentvalidation.net/
        }
    }
}
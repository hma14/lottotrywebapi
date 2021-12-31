namespace Lottotry.WebApi.Domain.DailyGrand.Validators
{

    using Lottotry.WebApi.Dtos.DailyGrand;
    using FluentValidation;

    public class DailyGrandForUpdateDtoValidator : DailyGrandForManipulationDtoValidator<DailyGrandForUpdateDto>
    {
        public DailyGrandForUpdateDtoValidator()
        {
            // add fluent validation rules that should only be run on update operations here
            //https://fluentvalidation.net/
        }
    }
}
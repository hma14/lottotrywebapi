namespace Lottotry.WebApi.Domain.DailyGrand.Validators
{

    using Lottotry.WebApi.Dtos.DailyGrand;
    using FluentValidation;

    public class DailyGrandForCreationDtoValidator : DailyGrandForManipulationDtoValidator<DailyGrandForCreationDto>
    {
        public DailyGrandForCreationDtoValidator()
        {
            // add fluent validation rules that should only be run on creation operations here
            //https://fluentvalidation.net/
        }
    }
}
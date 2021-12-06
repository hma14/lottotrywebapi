namespace Lottotry.WebApi.Domain.Numbers.Validators
{

    using Lottotry.WebApi.Dtos.Number;
    using FluentValidation;

    public class NumberForUpdateDtoValidator : NumberForManipulationDtoValidator<NumberForUpdateDto>
    {
        public NumberForUpdateDtoValidator()
        {
            // add fluent validation rules that should only be run on update operations here
            //https://fluentvalidation.net/
        }
    }
}
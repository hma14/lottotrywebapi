namespace Lottotry.WebApi.Domain.Numbers.Validators
{

    using Lottotry.WebApi.Dtos.Number;
    using FluentValidation;

    public class NumberForCreationDtoValidator : NumberForManipulationDtoValidator<NumberForCreationDto>
    {
        public NumberForCreationDtoValidator()
        {
            // add fluent validation rules that should only be run on creation operations here
            //https://fluentvalidation.net/
        }
    }
}
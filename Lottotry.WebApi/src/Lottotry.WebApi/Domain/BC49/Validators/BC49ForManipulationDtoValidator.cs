namespace Lottotry.WebApi.Domain.BC49.Validators
{
    using Lottotry.WebApi.Dtos.BC49;
    using FluentValidation;
    using System;

    public class BC49ForManipulationDtoValidator<T> : AbstractValidator<T> where T : BC49ForManipulationDto
    {
        public BC49ForManipulationDtoValidator()
        {
            // add fluent validation rules that should be shared between creation and update operations here
            //https://fluentvalidation.net/
        }
    }
}
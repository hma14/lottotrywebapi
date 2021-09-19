namespace Lottotry.WebApi.Domain.Lotto649.Validators
{
    using Lottotry.WebApi.Dtos.Lotto649;
    using FluentValidation;
    using System;

    public class Lotto649ForManipulationDtoValidator<T> : AbstractValidator<T> where T : Lotto649ForManipulationDto
    {
        public Lotto649ForManipulationDtoValidator()
        {
            // add fluent validation rules that should be shared between creation and update operations here
            //https://fluentvalidation.net/
        }
    }
}
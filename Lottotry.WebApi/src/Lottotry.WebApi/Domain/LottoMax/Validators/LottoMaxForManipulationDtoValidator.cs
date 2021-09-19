namespace Lottotry.WebApi.Domain.LottoMax.Validators
{
    using Lottotry.WebApi.Dtos.LottoMax;
    using FluentValidation;
    using System;

    public class LottoMaxForManipulationDtoValidator<T> : AbstractValidator<T> where T : LottoMaxForManipulationDto
    {
        public LottoMaxForManipulationDtoValidator()
        {
            // add fluent validation rules that should be shared between creation and update operations here
            //https://fluentvalidation.net/
        }
    }
}
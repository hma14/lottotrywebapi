namespace Lottotry.WebApi.Domain.LottoNumbers.Validators
{
    using Lottotry.WebApi.Dtos.LottoNumbers;
    using FluentValidation;
    using System;

    public class LottoNumbersForManipulationDtoValidator<T> : AbstractValidator<T> where T : LottoNumbersForManipulationDto
    {
        public LottoNumbersForManipulationDtoValidator()
        {
            // add fluent validation rules that should be shared between creation and update operations here
            //https://fluentvalidation.net/
        }
    }
}
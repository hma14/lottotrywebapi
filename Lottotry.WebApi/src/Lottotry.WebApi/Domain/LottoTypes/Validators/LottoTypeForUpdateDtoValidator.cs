namespace Lottotry.WebApi.Domain.LottoTypes.Validators
{

    using Lottotry.WebApi.Dtos.LottoType;
    using FluentValidation;

    public class LottoTypeForUpdateDtoValidator : LottoTypeForManipulationDtoValidator<LottoTypeForUpdateDto>
    {
        public LottoTypeForUpdateDtoValidator()
        {
            // add fluent validation rules that should only be run on update operations here
            //https://fluentvalidation.net/
        }
    }
}
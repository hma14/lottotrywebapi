namespace Lottotry.WebApi.Domain.LottoTypes.Validators
{

    using Lottotry.WebApi.Dtos.LottoType;
    using FluentValidation;

    public class LottoTypeForCreationDtoValidator : LottoTypeForManipulationDtoValidator<LottoTypeForCreationDto>
    {
        public LottoTypeForCreationDtoValidator()
        {
            // add fluent validation rules that should only be run on creation operations here
            //https://fluentvalidation.net/
        }
    }
}
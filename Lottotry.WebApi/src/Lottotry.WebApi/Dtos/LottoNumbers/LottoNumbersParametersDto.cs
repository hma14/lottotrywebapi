namespace Lottotry.WebApi.Dtos.LottoNumbers
{
    using Lottotry.WebApi.Dtos.Shared;
    using static Lottotry.WebApi.Dtos.Constants;

    public class LottoNumbersParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
        public LottoNames LottoName { get; set; }
    }
}
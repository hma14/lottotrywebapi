namespace Lottotry.WebApi.Dtos.LottoMax
{
    using Lottotry.WebApi.Dtos.Shared;

    public class LottoMaxParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
    }
}
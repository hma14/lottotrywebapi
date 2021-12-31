namespace Lottotry.WebApi.Dtos.DailyGrand
{

    using Lottotry.WebApi.Dtos.Shared;

    public class DailyGrandParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
    }
}
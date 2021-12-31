namespace Lottotry.WebApi.Dtos.DailyGrand_GrandNumber
{

    using Lottotry.WebApi.Dtos.Shared;

    public class DailyGrand_GrandNumberParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
    }
}
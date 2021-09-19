namespace Lottotry.WebApi.Dtos.Lotto649
{
    using Lottotry.WebApi.Dtos.Shared;

    public class Lotto649ParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
    }
}
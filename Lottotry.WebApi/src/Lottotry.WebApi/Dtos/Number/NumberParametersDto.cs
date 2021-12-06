namespace Lottotry.WebApi.Dtos.Number
{

    using Lottotry.WebApi.Dtos.Shared;

    public class NumberParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
    }
}
namespace Lottotry.WebApi.Dtos.BC49
{
    using Lottotry.WebApi.Dtos.Shared;

    public class BC49ParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
    }
}
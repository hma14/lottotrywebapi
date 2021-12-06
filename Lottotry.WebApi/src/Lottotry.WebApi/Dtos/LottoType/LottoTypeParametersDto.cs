namespace Lottotry.WebApi.Dtos.LottoType
{

    using Lottotry.WebApi.Dtos.Shared;
    using static Lottotry.WebApi.Dtos.Constants;

    public class LottoTypeParametersDto : BasePaginationParameters
    {
        public string Filters { get; set; }
        public string SortOrder { get; set; }
        public LottoNames LottoName { get; set; }
    }
}
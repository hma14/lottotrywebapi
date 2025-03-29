namespace Lottotry.WebApi.Domain.Users.Dtos;

using Lottotry.WebApi.Dtos.Shared;

public sealed class UserParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}

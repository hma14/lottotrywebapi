namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.Wrappers;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using QueryKit;
using QueryKit.Configuration;
using System;

public static class GetUserList
{
    public sealed record Query(UserParametersDto QueryParameters) : IRequest<PagedList<UserDto>>;

    public sealed class Handler(LottotryDbContext dbContext)
        : IRequestHandler<Query, PagedList<UserDto>>
    {
        public async Task<PagedList<UserDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.Users.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToUserDtoQueryable();

            return await PagedList<UserDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}

internal class CustomQueryKitConfiguration : QueryKitConfiguration
{
    public CustomQueryKitConfiguration() : base(settings =>
    {
        // Set property mappings if needed
        settings.PropertyMappings = new QueryKitPropertyMappings();

        // Allow unknown properties (optional)
        settings.AllowUnknownProperties = true;
    })
    {
    }
}
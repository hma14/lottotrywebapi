namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Domain.Users.Dtos;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public static class GetAllUsers
{
    public sealed record Query() : IRequest<List<UserDto>>;

    public sealed class Handler(LottotryDbContext dbContext)
        : IRequestHandler<Query, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            return dbContext.Users
                .AsNoTracking()
                .ToUserDtoQueryable()
                .ToList();
        }
    }
}
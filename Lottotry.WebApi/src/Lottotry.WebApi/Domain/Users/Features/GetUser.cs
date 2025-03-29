namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Domain.Users.Dtos;
using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public static class GetUser
{
    public sealed record Query(Guid UserId) : IRequest<UserDto>;

    public sealed class Handler(LottotryDbContext dbContext)
        : IRequestHandler<Query, UserDto>
    {
        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.UserId);
            return result.ToUserDto();
        }
    }
}
namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Databases;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Lottotry.WebApi.Domain.BC49.Features.DeleteBC49;

public static class DeleteUser
{
    public sealed record Command(int UserId) : IRequest<bool>;

    public sealed class Handler : IRequestHandler<Command, bool>
    {
        private readonly LottotryDbContext _dbContext;
        public Handler(LottotryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await _dbContext.Users
                .FirstOrDefaultAsync(b => b.Id == request.UserId);

            if (recordToDelete == null)
                throw new KeyNotFoundException();

            _dbContext.Users.Remove(recordToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }

}
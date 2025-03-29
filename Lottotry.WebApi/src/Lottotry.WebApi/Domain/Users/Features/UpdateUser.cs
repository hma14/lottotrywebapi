namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Domain.Users.Dtos;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public static class UpdateUser
{
    public sealed record Command(Guid UserId, UserForUpdateDto UpdatedUserData) : IRequest<bool>;

    public sealed class Handler(LottotryDbContext dbContext)
        : IRequestHandler<Command, bool>
    {
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var userToUpdate = await dbContext.Users.FirstOrDefaultAsync(b => b.Id == request.UserId);
            if (userToUpdate == null)
                return false;

            var userToAdd = request.UpdatedUserData.ToUserForUpdate();
            userToUpdate.Update(userToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
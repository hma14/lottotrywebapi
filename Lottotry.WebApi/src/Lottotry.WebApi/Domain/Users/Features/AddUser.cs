namespace Lottotry.WebApi.Domain.Users.Features;

using Lottotry.WebApi.Databases;
using Lottotry.WebApi.Domain.Users;
using Lottotry.WebApi.Domain.Users.Dtos;
using Mappings;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public static class AddUser
{
    public sealed record Command(UserForCreationDto UserToAdd) : IRequest<UserDto>;

    public sealed class Handler(LottotryDbContext dbContext)
        : IRequestHandler<Command, UserDto>
    {
        public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userToAdd = request.UserToAdd.ToUserForCreation();
            var user = User.Create(userToAdd);

            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return user.ToUserDto();
        }
    }
}
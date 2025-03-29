using System;

namespace Lottotry.WebApi.Domain.Users.DomainEvents;

public sealed class UserCreated : IDomainEvent
{
    public User User { get; set; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;


}
            
using System;

namespace Lottotry.WebApi.Domain.Users.DomainEvents;

public sealed class UserUpdated //: DomainEvents
{
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
            
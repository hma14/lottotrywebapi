using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Domain
{
    

    public class BaseEntity
    {
        public  virtual Guid Id { get; set; }
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void QueueDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }

    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }

    public class DomainEvents : IDomainEvent
    {
        public DateTime OccurredOn => DateTime.Now;
    }
}

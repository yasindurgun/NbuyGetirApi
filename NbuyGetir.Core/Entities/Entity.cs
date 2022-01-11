using NbuyGetir.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entities
{
    class Entity : IEntity
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public void AddEvents(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }
    }
}

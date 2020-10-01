using System;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IDomainEventRasier
    {
        Task Raise<T>(T @event) where T : IDomainEvent;
    }
}

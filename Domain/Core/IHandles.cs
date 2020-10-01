using System;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IHandles<T> where T : IDomainEvent
    {
        Task Handle(T @event);
    }
}

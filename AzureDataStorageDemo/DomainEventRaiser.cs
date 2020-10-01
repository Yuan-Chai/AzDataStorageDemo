using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Core;

namespace AzureDataStorageDemo
{
    public class DomainEventRaiser : IDomainEventRasier
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventRaiser(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Raise<T>(T @event) where T : IDomainEvent
        {
            var handlers = (IHandles<T>[])_serviceProvider.GetService(typeof(IEnumerable<IHandles<T>>));

            if (handlers.Length > 0)
            {
                foreach (var handler in handlers)
                {
                    await handler.Handle(@event);
                }
            }
        }
    }
}

using System;
using System.Threading.Tasks;

using Domain.Core;
using Domain.Events;

namespace TableStorage
{
    public class CreateUserHandler : IHandles<CreateUserEvent>
    {
        private readonly ITableClient _tableClient;

        public CreateUserHandler(ITableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public async Task Handle(CreateUserEvent @event)
        {
            var entity = new UserEntity(Guid.NewGuid().ToString(), @event.LastName)
            {
                FirstName = @event.FirstName,
                LastName = @event.LastName
            };
            await _tableClient.Save(entity);
        }
    }
}

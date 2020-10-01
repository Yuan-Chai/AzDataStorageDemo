using System;
using System.Threading.Tasks;

using Domain.Core;
using Domain.Events;

namespace BlobStorage
{
    public class CreateUserHandler : IHandles<CreateUserEvent>
    {
        private readonly IBlobClient _blobClient;

        public CreateUserHandler(IBlobClient blobClient)
        {
            _blobClient = blobClient;
        }

        public async Task Handle(CreateUserEvent @event)
        {
            var logValue = $"EventId: {@event.EventId}, Event: CreateUser, FullName: {@event.FirstName} {@event.LastName}";

            await _blobClient.AppendLog(logValue);
        }
    }
}

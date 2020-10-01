using System;
using System.Threading.Tasks;

using AzureDataStorageDemo.Models;

using Domain.Core;
using Domain.Events;

namespace AzureDataStorageDemo
{

    public interface IUserService
    {
        Task Create(CreateUserModel createUser);
    }

    public class UserService : IUserService
    {
        private readonly IDomainEventRasier _eventRasier;

        public UserService(IDomainEventRasier eventRasier)
        {
            _eventRasier = eventRasier;
        }

        public async Task Create(CreateUserModel createUser)
        {
            await _eventRasier.Raise<CreateUserEvent>(new CreateUserEvent(createUser.FirstName, createUser.LastName));
        }
    }
}

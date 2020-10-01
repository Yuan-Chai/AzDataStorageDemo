using System;

using Domain.Core;

namespace Domain.Events
{
    public class CreateUserEvent : IDomainEvent
    {
        public string EventId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public CreateUserEvent(string firstName, string lastName)
        {
            EventId = Guid.NewGuid().ToString();
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

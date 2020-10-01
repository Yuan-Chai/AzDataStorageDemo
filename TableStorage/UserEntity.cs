using System;

using Microsoft.Azure.Cosmos.Table;

namespace TableStorage
{
    public class UserEntity : TableEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(string id, string lastName)
        {
            PartitionKey = lastName;
            RowKey = id;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

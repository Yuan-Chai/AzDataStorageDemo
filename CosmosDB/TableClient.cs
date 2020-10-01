using System;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;

namespace CosmosDb
{

    public interface ITableClient
    {
        Task Save(UserEntity userEntity);
    }
    public class TableClient : ITableClient
    {
        private readonly CosmosOptions _tableStorageSettings;

        public TableClient(IOptions<CosmosOptions> options)
        {
            _tableStorageSettings = options.Value;
        }

        public async Task Save(UserEntity userEntity)
        {
            var cloudAccount = CloudStorageAccount.Parse(_tableStorageSettings.ConnectionString);

            var tableClient = cloudAccount.CreateCloudTableClient();

            var tableRef = tableClient.GetTableReference(_tableStorageSettings.TableName);

            await tableRef.CreateIfNotExistsAsync();

            TableOperation operation = TableOperation.Insert(userEntity);

            await tableRef.ExecuteAsync(operation);
        }
    }
}

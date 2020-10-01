using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

using Microsoft.Extensions.Options;

namespace BlobStorage
{
    public interface IBlobClient
    {
        Task AppendLog(string value);
    }

    public class BlobClient : IBlobClient
    {
        private readonly BlobStorageOptions _blobStorageSettings;

        public BlobClient(IOptions<BlobStorageOptions> options)
        {
            _blobStorageSettings = options.Value;
        }

        public async Task AppendLog(string value)
        {
            var blobContainerClient = new BlobContainerClient(_blobStorageSettings.ConnectionString, _blobStorageSettings.ContainerName);

            await blobContainerClient.CreateIfNotExistsAsync();

            var fileSuffix = DateTime.UtcNow.Date.ToString();

            var blob = blobContainerClient.GetAppendBlobClient($"{_blobStorageSettings.FilePrefix}-{fileSuffix}");

            await blob.CreateIfNotExistsAsync();

            var content = $"{value} \n";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            await blob.AppendBlockAsync(stream);
        }
    }
}

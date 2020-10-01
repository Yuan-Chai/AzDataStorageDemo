using System;
namespace BlobStorage
{
    public class BlobStorageOptions
    {
        public string ConnectionString { get; set; }

        public string ContainerName { get; set; }

        public string FilePrefix { get; set; }

    }
}

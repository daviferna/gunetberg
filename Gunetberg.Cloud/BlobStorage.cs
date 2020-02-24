using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace Gunetberg.Cloud
{
    public class BlobStorage
    {
        private CloudBlobContainer _container;

        public BlobStorage(string connectionString, string container)
        {
            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                var cloudBlobClient = storageAccount.CreateCloudBlobClient();
                _container = cloudBlobClient.GetContainerReference(container);
            }
        }

        public async Task Upload(byte[] data, string name)
        {
            var cloudBlockBlob = _container.GetBlockBlobReference(name);
            await cloudBlockBlob.UploadFromByteArrayAsync(data, 0, data.Length);
        }
    }
}

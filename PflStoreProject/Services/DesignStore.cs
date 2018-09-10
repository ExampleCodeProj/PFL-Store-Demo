using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PflStoreProject.Services
{
    public class DesignStore
    {
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;
        private CloudBlockBlob _blob;
        string baseUri = "https://pflstorage.blob.core.windows.net/";

//        TODO: secure credentials in app settings or key vault
        private string Key = "vcby/WpQcK7I+jmmOstgYI2KKQrJ1I7Ob6DkK4fY8DxIGBa1uOxIlSz/eIXVKV/8rqGZm8ANsdJOIjQ9btz3dw==";
        private string account = "pflstorage";

        public DesignStore()
        {
            var credentials = new StorageCredentials(account, Key);
            _blobClient = new CloudBlobClient(new Uri(baseUri), credentials);
            _container = _blobClient.GetContainerReference("design-files");
        }

        public async Task<string> SaveFile(Stream dataStream)
        {
            var fileName = new Guid().ToString();
            
            _blob = _container.GetBlockBlobReference(fileName);
            await _blob.UploadFromStreamAsync(dataStream);
            var accessPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-1)
            };
            var sas = _blob.GetSharedAccessSignature(accessPolicy);
            return $"{baseUri}design-files/{fileName}{sas}";
        }


    }
}

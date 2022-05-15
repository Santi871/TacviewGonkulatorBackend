using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;

namespace TacviewGonkulatorBackend.Services
{
    public record AzureStorageConfig
    {
        public string AccountKey { get; set; }
        public string AccountName { get; set; }
        public string ImageContainer { get; set; }
    }
    
    public interface IFileStorageService
    {
        Task<Uri> UploadFileToStorage(Stream fileStream, string fileName);
        Uri GetUriToTacview(string fileName);
    }

    public class AzureFileStorageService : IFileStorageService
    {
        private readonly AzureStorageConfig _config;
        
        public AzureFileStorageService(AzureStorageConfig config)
        {
            _config = config;
        }

        public async Task<Uri> UploadFileToStorage(Stream fileStream, string fileName)
        {
            var blobUri = GetUriToTacview(fileName);
            
            var storageCredentials = new StorageSharedKeyCredential(_config.AccountName, _config.AccountKey);
            
            var blobClient = new BlobClient(blobUri, storageCredentials);
            
            await blobClient.UploadAsync(fileStream);
            return blobUri;
        }

        public Uri GetUriToTacview(string fileName)
        {
            return new Uri("https://" + _config.AccountName +
                           ".blob.core.windows.net/" +
                           _config.ImageContainer +
                           "/" + fileName);
        }
    }
}
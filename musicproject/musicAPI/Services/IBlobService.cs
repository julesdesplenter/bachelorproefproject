using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ECommerce.API.Services
{
    public interface IBlobService
    {
        Task DeleteBlobAsync(string blobName);
        Task<Stream> GetBlobAsync(string name);
        Task<IEnumerable<string>> ListBlobAsync();
        Task UploadContent(string content, string fileName);
        Task UploadFile(IFormFile asset);
    }
}
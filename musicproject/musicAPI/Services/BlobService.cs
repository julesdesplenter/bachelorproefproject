using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.API.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<Stream> GetBlobAsync(string name)
        {
            MemoryStream ms = new MemoryStream();
            var containerClient = blobServiceClient.GetBlobContainerClient("songs");
            //if (await containerClient.ExistsAsync())
            //{
                var client = containerClient.GetBlobClient(name);

                //if (await client.ExistsAsync())
                //{
                    await client.DownloadToAsync(ms);
                    Stream blobStream = client.OpenReadAsync().Result;
                    return blobStream;
            //    }
            //    else
            //    {
            //        //return Content("File does not exist");
            //    }
            //}
            //else
            //{
            //    //return Content("Container does not exist");
            //}
        }

        public async Task<IEnumerable<string>> ListBlobAsync()
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("songs");
            var items = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }
            return items;
        }

   
        public async Task UploadFile(IFormFile asset)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("songs");
            var blobClient = containerClient.GetBlobClient(asset.FileName);
            byte[] bytes = new byte[0];
            using (var memoryStream = new MemoryStream())
            {
                await asset.CopyToAsync(memoryStream);
                bytes = memoryStream.ToArray();
            }
            await using var memorystream = new MemoryStream(bytes);
            await blobClient.UploadAsync(memorystream, new BlobHttpHeaders { ContentType = asset.FileName.GetContentType() });
        }

        public async Task UploadContent(string content, string fileName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("songs");
            var blobClient = containerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
            await using var memorystream = new MemoryStream(bytes);
            await blobClient.UploadAsync(memorystream, new BlobHttpHeaders { ContentType = fileName.GetContentType() });
        }

        public async Task DeleteBlobAsync(string blobName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient("songs");
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }
      
    }
}

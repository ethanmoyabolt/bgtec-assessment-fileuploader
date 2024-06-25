using Azure.Storage;
using Azure.Storage.Blobs;
using FileUploader.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader
{
    public class FileService : IFileService
    {
        // Initialises connection to Blob Storage

        private readonly string _storageAccount = "mystorage230984570283745";
        private readonly string _key = "9F/FZBABRBKTwxugB1+7wAiqlZCu9GoHGBn6HiNMOMFC+veNNiW+Zm3WFT9Jsot7CQFi2vnRiiH8+AStaa3pjQ==";
        private readonly BlobContainerClient _filesContainer;


        public FileService()
        {
            var credential = new StorageSharedKeyCredential(_storageAccount, _key);
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _filesContainer = blobServiceClient.GetBlobContainerClient("files");
        }

        public async Task<BlobResponseDto> UploadAsync (IFormFile blob)
        {
            BlobResponseDto response = new();

            // Initialises the client using the file provided
            BlobClient client = _filesContainer.GetBlobClient(blob.FileName);


            // Attempts to upload the file, catching the exception that is thrown if there is an error.
            try
            {
                await using (Stream data = blob.OpenReadStream())
                {
                    await client.UploadAsync(data);
                }

                response.Status = $"File {blob.FileName} Uploaded Successfully";
                response.Error = false;
                response.Blob.Uri = client.Uri.AbsoluteUri;
                response.Blob.Name = client.Name;
            }
            catch (Azure.RequestFailedException)
            {
                response.Status = "An error has occurred when uploading this file";
                response.Error = true;
            }

            return response;
        }
    }
}

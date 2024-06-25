using FileUploader.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader
{
    public interface IFileService
    {
        // Interface for FileService to allow for dependency injection.
        Task<BlobResponseDto> UploadAsync(IFormFile blob);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public class BlobResponseDto
    {
        // Data transfer object to be able to pass throught the response from the blob storage when trying to upload a file

        public BlobResponseDto()
        {
            Blob = new BlobDto();
        }

        public string Status { get; set; }
        public bool Error { get; set; }

        public BlobDto Blob { get; set; }
    }
}

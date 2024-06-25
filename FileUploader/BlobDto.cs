using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public class BlobDto
    {
        // Used to initialise an object that can be used to upload files to the blob storage,

        public string Uri { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public Stream Content { get; set; }


    }
}

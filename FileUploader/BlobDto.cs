using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public class BlobDto
    {
        public string? Uri { get; set; }

        public string? Name { get; set; }

        public string? ContentType { get; set; }

        public Stream? Content { get; set; }


    }
}

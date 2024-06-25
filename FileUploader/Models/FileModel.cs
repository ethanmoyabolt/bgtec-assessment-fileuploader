using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public class FileModel
    {

        // Creates an instance of the file to be added to the database.
        public FileModel(Guid fileId, string fileName, long size, string contentType, string fileExtension, DateTime time, string filePath)
        {
            FileId = fileId;
            FileName = fileName;
            Size = size;
            ContentType = contentType;
            FileExtension = fileExtension;
            Time = time;
            FilePath = filePath;
        }

        public Guid FileId { get; set; }

        public string FileName { get; set; }

        public long Size { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public DateTime Time { get; set; }

        public string FilePath { get; set; }

    }
}

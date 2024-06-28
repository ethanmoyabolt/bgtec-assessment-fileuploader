using System;
using System.ComponentModel.DataAnnotations;

namespace FileUploader.Models
{
    public class FileModel
    {

        // Creates an instance of the file to be added to the database.
        public FileModel(Guid fileId, string fileName, long size, string contentType, string fileExtension, DateTime time, string filePath)
        {
            FileID = fileId;
            FileName = fileName;
            Size = size;
            ContentType = contentType;
            FileExtension = fileExtension;
            Time = time;
            FilePath = filePath;
        }


        // Default

        public FileModel()
        {

        }

        [Key]
        public Guid FileID { get; set; }

        public string FileName { get; set; }

        public long Size { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public DateTime Time { get; set; }

        public string FilePath { get; set; }

    }
}

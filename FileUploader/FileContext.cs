using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public class FileContext : DbContext
    {
        // Context used to query and save instances of the file model to be able to communicate with the database

        public FileContext(DbContextOptions<FileContext> options) : base(options) { }

        public DbSet<FileModel> Files { get; set; }


    }
}

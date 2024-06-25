using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploader.Models
{
    public class HomeViewModel
    {
        // File to be passed to controller
        public IFormFile File { get; set; }

    }
}

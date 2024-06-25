using FileUploader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace FileUploader.Controllers
{
    public class HomeController : Controller
    {
        // FileService and Database Context initialised to allow the controller to upload files as well as add to the database.
        private readonly ILogger<HomeController> _logger;
        private readonly IFileService _fileService;
        private FileContext _context;


        public HomeController(ILogger<HomeController> logger, IFileService fileService, FileContext ctx)
        {
            _logger = logger;
            _fileService = fileService;
            _context = ctx;
        }


        [HttpPost]
        public IActionResult Upload()
        {
            // Passes in vewmodel in order to retrieve the file selected in the form of an IFormFile
            HomeViewModel model = new HomeViewModel();
            return View(model);
        }


        [HttpGet]
        public IActionResult ViewFiles()
        {
            // Passes the data from the datbase to the viewbag so it can be displayed in the view
            ViewBag.files = _context.Files.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(HomeViewModel model)
        {
            // Calls the upload method from the file service
            var result = await _fileService.UploadAsync(model.File);

            // Created Unique ID in the form of a GUID for the new File
            Guid FileId = Guid.NewGuid();

            // Gets extension of file from FileName
            string ext = Path.GetExtension(model.File.FileName);
            
            // Checks there has been no error uploading the file then logs the newly uploaded file to the database;
            if (!result.Error)
            {
                _context.Files.Add(new FileModel(FileId, model.File.FileName, model.File.Length, model.File.ContentType, ext, DateTime.Now, model.File.FileName));
            }
            _context.SaveChanges();
            return Ok(result);
        }
    }
}

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
        private FileContext Context { get; set; }


        public HomeController(ILogger<HomeController> logger, IFileService fileService, FileContext ctx)
        {
            _logger = logger;
            _fileService = fileService;
            Context = ctx;
        }


        [HttpPost]
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            return View(model);
        }


        [HttpGet]
        public IActionResult Privacy()
        {
            ViewBag.files = Context.Files.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(HomeViewModel model)
        {
            var result = await _fileService.UploadAsync(model.File);
            Guid FileId = new Guid();
            string ext = Path.GetExtension(model.File.FileName);
            if (!result.Error)
            {
                Context.Files.Add(new FileModel(FileId, model.File.FileName, model.File.Length, model.File.ContentType, ext, DateTime.Now, model.File.FileName));
            }
            Context.SaveChanges();
            return Ok(result);
        }
    }
}

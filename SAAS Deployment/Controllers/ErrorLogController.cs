using Microsoft.AspNetCore.Mvc;
using SAAS_Deployment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace SAAS_Deployment.Controllers
{
    public class ErrorLogController : Controller
    {
        private IWebHostEnvironment Environment;

        public ErrorLogController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult Index()
        {
            //this.Environment.WebRootPath for wwwroot folder listing if wanted
            string[] filePaths = Directory.GetFiles(Path.Combine(this.Environment.ContentRootPath, "Logs/"));

            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }
        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(this.Environment.ContentRootPath, "Logs/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}

using ImageUploadsWithLikesEF.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ImageUploadsWithLikesEF.Web.Controllers
{
    public class UploadController : Controller
    {
        private string _connectionString;
        private IWebHostEnvironment _environment;
        public UploadController(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _connectionString=configuration.GetConnectionString("ConStr");
        }
     
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload(string title, IFormFile imageFile)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            string fullPath = Path.Combine(_environment.WebRootPath, "uploads", fileName);
            using var stream = new FileStream(fullPath, FileMode.CreateNew);
            imageFile.CopyTo(stream);
            

            var image = new Image { Title=title, FileName=Path.Combine("uploads",fileName), UploadedAt=DateTime.Now };
            var repo = new ImageRepository(_connectionString);
            repo.AddImage(image);
            return Redirect("/");
        }
    }
}

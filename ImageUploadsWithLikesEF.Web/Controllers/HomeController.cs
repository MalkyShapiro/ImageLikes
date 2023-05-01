using ImageUploadsWithLikesEF.Data;
using ImageUploadsWithLikesEF.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace ImageUploadsWithLikesEF.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        public HomeController(IConfiguration configuration)
        {
            _connectionString=configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            var repo = new ImageRepository(_connectionString);
            return View(new HomePageViewModel
            {
                Images=repo.GetImages()
            });


        }
        public IActionResult ViewImage(int id)
        {
            var repo = new ImageRepository(_connectionString);
            return View(new ViewImageViewModel
            {
                Image=repo.GetById(id),

             });


        }


        [HttpPost]
        public IActionResult Like(int id)
        {
            var repo = new ImageRepository(_connectionString);
            repo.LikeImage(id);
            return Redirect("/home/viewimage/");
        }

    }
}

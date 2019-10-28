using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;
        public HomeController(DataContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            Request model = new Request();
            model.Email = "tnhn@gmail.com";
            model.Message = "Kursa katılmayı istiyorum.";
            model.Name = "Tunahan KETÇİ";
            model.Phone = "532 532 32 32";
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            db.Requests.Add(model);
            db.SaveChanges();
            return View("Thanks", model);
        }
    }
}
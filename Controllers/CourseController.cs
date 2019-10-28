using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository repo;
        public CourseController(ICourseRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult Index(string name=null,decimal? price=null,string isActive=null)
        {
            var courses = repo.GetCoursesByFilter(name, price, isActive);
            ViewBag.Name = name;
            ViewBag.Price = price;
            ViewBag.IsActive = isActive=="on"?true:false;
               
            return View(courses);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.ActionMode = "Edit";
            return View(repo.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Course entity,Course original)
        {
            repo.UpdateCourse(entity, original);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View("Edit", new Course());
        }
        [HttpPost]
        public IActionResult Create(Course newCourse)
        {
            int id = repo.CreateCourse(newCourse);
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            repo.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
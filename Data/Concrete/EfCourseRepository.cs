using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class EfCourseRepository : ICourseRepository
    {
        private DataContext db;
        public EfCourseRepository(DataContext _db)
        {
            db = _db;
        }
        public IQueryable<Course> Courses => db.Courses;

        public int CreateCourse(Course newCourse)
        {
            db.Courses.Add(newCourse);
            db.SaveChanges();
            return newCourse.Id;//burdan id geri dönerse kayıt işlemi başarılı dönmezse başarısız.
        }

        public void DeleteCourse(int courseid)
        {
            db.Courses.Remove(new Course() { Id = courseid });
            db.SaveChanges();
        }

        public Course GetById(int CourseId)
        {
           return db.Courses.Find(CourseId);
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null)
        {
            IQueryable<Course> query = db.Courses;
            if(name!=null)
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }
            if (price != null)
            {
                query = query.Where(x => x.Price >= price);
            }
            if (isActive == "on")
            {
                query = query.Where(x => x.IsActive == true);
            }
            return query.ToList();
        }

        public void UpdateAll(int id, Course[] courses)
        {
            db.Courses.UpdateRange(courses.Where(i => i.InstructorId != id));
            db.SaveChanges();
        }

        public void UpdateCourse(Course updateCourse, Course originalCourse = null)
        {
            if (originalCourse==null)
            {
                originalCourse = db.Courses.Find(updateCourse.Id);
            }
            else
            {
                db.Courses.Attach(originalCourse);
            }
            originalCourse.Name = updateCourse.Name;
            originalCourse.Price = updateCourse.Price;
            originalCourse.IsActive = updateCourse.IsActive;

            db.SaveChanges();


           // EntityEntry entry = db.Entry(originalCourse);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        Course GetById(int CourseId);
        IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null);
        IEnumerable<Course> GetCourses();
        int CreateCourse(Course newCourse);
        void UpdateCourse(Course updateCourse, Course originalCourse = null);
        void DeleteCourse(int courseid);
        void UpdateAll(int id, Course[] courses);
    }
}

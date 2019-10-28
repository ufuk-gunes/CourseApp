using CourseApp.Data.Abstract;
using CourseApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Data.Concrete
{
    public class EfInstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private DataContext db;
        public EfInstructorRepository(DataContext _db):base(_db)
        {
            db = _db;
        }
        public IEnumerable<Instructor> GetTopInstructor()
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Instructor> GetAll()
        {
            db.Courses.Where(x => x.Instructor != null).Load();
            return db.Instructors;
        }
    }
}

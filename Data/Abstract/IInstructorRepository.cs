using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Data.Abstract
{
    public interface IInstructorRepository:IGenericRepository<Instructor>
    {
        IEnumerable<Instructor> GetTopInstructor();
    }
}

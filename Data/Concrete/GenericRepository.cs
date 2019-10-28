using CourseApp.Data.Abstract;
using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DataContext db;
        public GenericRepository(DataContext _db)
        {
            db = _db;
        }
        public void Delete(int id)
        {
            db.Remove<TEntity>(Get(id));
            db.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            db.Add<TEntity>(entity);
            db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            db.Update<TEntity>(entity);
            db.SaveChanges();
        }
    }
}

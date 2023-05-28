using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _object;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _object = _dbContext.Set<T>();
        }

        public int Delete(T p)
        {
            _object.Remove(p);
            return _dbContext.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }
        public bool Any(Expression<Func<T, bool>> where)
        {
            return _object.Any(where);
        }
        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return _dbContext.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _object.Where(where).ToList();
        }

        public int Update(T p)
        {
            var updatedEntity = _dbContext.Entry(p);
            updatedEntity.State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}

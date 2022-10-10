using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BussinessLogic.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _Context;

        public Repository(ApplicationDbContext _Context)
        {
            this._Context = _Context;
        }

        public IEnumerable<T> GetAll()
        {
            var query = _Context.Set<T>().AsQueryable();
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = _Context.Set<T>().AsQueryable();

            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(exp);
        }

        public void Add(T entity)
        {
            _Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entity = _Context.Set<T>().Find(id);
            _Context.Set<T>().Remove(entity);
        }

        public bool IsExists(Expression<Func<T, bool>> exp)
        {
            return _Context.Set<T>().Any(exp);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}

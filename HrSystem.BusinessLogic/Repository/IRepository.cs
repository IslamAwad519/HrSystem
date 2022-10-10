using System.Linq.Expressions;

namespace BussinessLogic.Repositories
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public T Get(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);

        public void Add(T entity);

        public void Update(T entity);

        public void Delete(int id);

        public bool IsExists(Expression<Func<T, bool>> exp);

        public void SaveChanges();
    }
}

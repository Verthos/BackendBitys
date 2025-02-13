using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;
using Infrastructure.DatabaseContext;


namespace Infrastructure.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApiContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }


}

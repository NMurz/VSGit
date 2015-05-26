using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data.Repositories.GenericResository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly IContext<T> context;

        public GenericRepository()
        {
            context = new Context<T>();
        }
        public IQueryable<T> GetAll()
        {
            return context.DbSet;
        }

        public IQueryable<T> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = context.DbSet.Where(predicate);
            return result;
        }

        public T GetSingleBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = context.DbSet.SingleOrDefault(predicate);
            return result;
        }

        public T Add(T entity)
        {
            return context.DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            context.DbSet.Remove(entity);
        }

        public void Edit(T entity)
        {
            context.DbSet.Attach(entity);
            context.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            context.DbContext.Dispose();
        }
    }
}

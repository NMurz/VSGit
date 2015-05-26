using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data.Repositories.GenericResository
{
    public interface IGenericRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        T GetSingleBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Remove(T entity);
        void Edit(T entity);
        void Save();
        void Dispose();
    }
}

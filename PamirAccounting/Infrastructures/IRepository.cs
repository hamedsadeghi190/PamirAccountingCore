using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PamirAccounting.Infrastructures
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll(Expression<Func<T, bool>> where = null, string includes = "");
        IQueryable<T> FindAllReadonly(Expression<Func<T, bool>> where = null, string includes = "");
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> where = null, string includes = "");
        Task<IEnumerable<T>> FindAllReadonlyAsync(Expression<Func<T, bool>> where = null, string includes = "");
        T Find(object id);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
        Task InsertRangeAsync(IEnumerable<T> entities);
        T FindFirst(Expression<Func<T, bool>> where = null, string includes = "");
        Task<T> FindFirstAsync(Expression<Func<T, bool>> where = null, string includes = "");
        T FindFirstOrDefault(Expression<Func<T, bool>> where = null, string includes = "");
        Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> where = null, string includes = "");
        IEnumerable<object> where(Func<object, bool> p);
    }
}

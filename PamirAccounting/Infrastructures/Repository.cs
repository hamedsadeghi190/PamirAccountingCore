using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PamirAccounting.Infrastructures
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        private readonly DbSet<T> Local;
        readonly string errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            _context = context;
            Local = context.Set<T>();
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> where = null, string includes = "")
        {
            IQueryable<T> data = Local;
            if (!string.IsNullOrEmpty(includes))
            {
                data = includes.Split(',').Aggregate(data, (current, inc) => current.Include(inc.Trim()));
            }
            if (where != null)
                data = data.Where(where);
            return data;
        }

        public virtual IQueryable<T> FindAllReadonly(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return FindAll(where, includes).AsNoTracking();
        }

        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return await FindAll(where, includes).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAllReadonlyAsync(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return await FindAllReadonly(where, includes).ToListAsync();
        }

        public virtual T Find(object id)
        {
            return Local.Find(id);
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Local.Add(entity);
        }

        public virtual async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Local.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
          
            Local.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            Delete(Find(id));
        }

        public virtual async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            Local.AddRange(entities);
        }

        public virtual T FindFirst(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return FindAll(where, includes).First();
        }
        public virtual async Task<T> FindFirstAsync(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return await FindAll(where, includes).FirstAsync();
        }

        public virtual T FindFirstOrDefault(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return FindAll(where, includes).FirstOrDefault();
        }
        public virtual async Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> where = null, string includes = "")
        {
            return await FindAll(where, includes).FirstOrDefaultAsync();
        }

        public IEnumerable<object> where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
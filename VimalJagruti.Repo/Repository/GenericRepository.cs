using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Repo.IRepository;
using VimalJagruti.Utils.ExtensionMethods;

namespace VimalJagruti.Repo.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentException("An instance of DbContext is " +
                                            "required to use this repository.", nameof(context));
            Context = context;
            DbSet = Context.Set<T>();
        }
        protected DbSet<T> DbSet { get; set; }
        protected DbContext Context { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int? PageNo = null, int? PageSize = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

            if (orderBy != null)
            {
                if ((PageNo != null && PageSize != null) && (PageNo >= 0 && PageSize > 0))
                    return orderBy(query).GetPaged(PageNo.Value, PageSize.Value).Results.ToList();
                else
                    return orderBy(query).ToList();
            }
            else
            {
                if ((PageNo != null && PageSize != null) && (PageNo >= 0 && PageSize > 0))
                    return query.GetPaged(PageNo.Value, PageSize.Value).Results.ToList();
                else
                    return query.ToList();
            }
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int? PageNo = null, int? PageSize = null)
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

            if (orderBy != null)
            {
                if ((PageNo != null && PageSize != null) && (PageNo >= 0 && PageSize > 0))
                    return await orderBy(query).GetPaged(PageNo.Value, PageSize.Value).Results.ToListAsync();
                else
                    return await orderBy(query).ToListAsync();
            }
            else
            {
                if ((PageNo != null && PageSize != null) && (PageNo >= 0 && PageSize > 0))
                    return await query.GetPaged(PageNo.Value, PageSize.Value).Results.ToListAsync();
                else
                    return await query.ToListAsync();
            }
        }

        public virtual async Task<T> GetById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).SingleOrDefaultAsync();
        }


        public virtual async Task<bool> Add(T entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
                entry.State = EntityState.Added;
            else
                DbSet.Add(entity);

            await Context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
                DbSet.Attach(entity);

            entry.State = EntityState.Modified;

            await Context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }

            await Context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Delete(long id)
        {
            var entity = await GetById(id);

            if (entity != null)
                await Delete(entity);

            return true;
        }

        public virtual async Task<bool> Detach(T entity)
        {
            var entry = Context.Entry(entity);

            entry.State = EntityState.Detached;

            await Context.SaveChangesAsync();
            return true;
        }
    }
}

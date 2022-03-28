using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VimalJagruti.Repo.IRepository
{
    /// <summary>
    /// One class that defined CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? PageNo = null,
            int? PageSize = null);

        Task<IEnumerable<T>> GetListAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? PageNo = null,
            int? PageSize = null);

        Task<T> GetById(int id);
        Task<T> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);

        Task<bool> Add(T entity);
        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);
        Task<bool> Delete(int id);
        Task<bool> Detach(T entity);
    }
}

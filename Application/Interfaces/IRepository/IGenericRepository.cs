using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> FirstOrDefaultAsync
        (Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>,IQueryable<T>> include = null);
        Task<List<T>> GetAllAsync
        (Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>,IQueryable<T>> include = null);
        Task AddAsync(T entity);
    }
}

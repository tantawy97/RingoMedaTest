using Application.Interfaces.IRepository;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected readonly RingoMediaContext _context;

        public GenericRepository(RingoMediaContext context)
        {
            _context = context;
        }
        public async Task<T?> FirstOrDefaultAsync(
           Expression<Func<T, bool>> predicate,
           Func<IQueryable<T>,IQueryable<T>> include = null)
        {
            var query = _context.Set<T>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (include != null)
                query = include(query);
            var a=query.ToQueryString();
            var x = await query.FirstOrDefaultAsync();
            return x ;
        } 
        public async Task<List<T>> GetAllAsync(
           Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>,
           IQueryable<T>> include = null
            )
        {
            var query = _context.Set<T>().AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public List<Department> GetDepartmentHierarchy(IQueryable<Department> departments, long startId)
        {
            // Initialize the result list
            var result = new List<Department>();

            // Recursive method to process departments
            void ProcessDepartment(List<Department> currentDepartments)
            {
                if (currentDepartments.Count == 0)
                {
                    return;
                }

                // Add the current departments to the result
                result.AddRange(currentDepartments.Select(d => new Department
                {
                    Id = d.Id,
                    Name = d.Name,
                    ParentDepartmentId = d.ParentDepartmentId
                }));

                // Find all children for the current departments
                var childIds = currentDepartments.Select(d => d.Id).ToList();
                var children = departments.Where(d => childIds.Contains(d.ParentDepartmentId ?? 0)).ToList();

                // Process the next level of departments
                ProcessDepartment(children);
            }

            // Load the starting department
            var startDepartment = departments.FirstOrDefault(d => d.Id == startId);
            if (startDepartment != null)
            {
                ProcessDepartment(new List<Department> { startDepartment });
            }

            // Order the results if needed (optional)
            return result.OrderBy(d => d.Id).ToList();
        }

    }
}

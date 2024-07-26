using Application.Interfaces.IRepository;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RingoMediaContext context):base(context) { }

        public async Task<(Department,List<Department>)> GetByIdAsync(long id)
        {
           var department =await _context.Departments
                .Include(w=>w.SubDepartments)
                .Include(w=>w.ParentDepartment)
                .FirstOrDefaultAsync(department => department.Id == id);
           var parents = IncludeParents(department?.ParentDepartment);
            return (department, parents);

        }
        private List<Department> IncludeParents(Department department)
        {
            var parents = new List<Department>();
            Department currentDepartment = department;

            while (currentDepartment != null)
            {
                _context.Entry(currentDepartment).Reference(e => e.ParentDepartment).Load();
                parents.Add(currentDepartment);
                currentDepartment = currentDepartment.ParentDepartment;
            };
            parents.Reverse();
            return parents;
        }
    }
}

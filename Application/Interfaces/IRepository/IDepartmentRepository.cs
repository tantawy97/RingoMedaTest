using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public Task<(Department, List<Department>)> GetById(long id);
    }
}

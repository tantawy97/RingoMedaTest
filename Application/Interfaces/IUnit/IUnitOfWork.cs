using Application.Interfaces.IRepository;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IUnit
{
    public interface IUnitOfWork:IDisposable
    {
        IDepartmentRepository Department { get; }
        Task<int> Save();

    }
}

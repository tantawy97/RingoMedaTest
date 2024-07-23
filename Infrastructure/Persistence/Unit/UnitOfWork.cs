using Application.Interfaces.IRepository;
using Application.Interfaces.IUnit;
using Core.Entities;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Unit
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly RingoMediaContext _context;

        public IDepartmentRepository Department { get; private set; }

        public UnitOfWork(RingoMediaContext context)
        {
            _context = context;
            Department =new DepartmentRepository(_context);

        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

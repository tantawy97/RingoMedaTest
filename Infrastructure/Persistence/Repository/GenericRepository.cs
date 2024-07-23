using Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly RingoMediaContext _context;

        public GenericRepository(RingoMediaContext context)
        {
            _context = context;
        }
    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class RingoMediaContext : DbContext
    {
        public RingoMediaContext() { }
        #region Entities
        public virtual DbSet<Department> Departments { get; set; }
        #endregion
    }
}


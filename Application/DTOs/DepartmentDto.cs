using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DepartmentDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
    }
}

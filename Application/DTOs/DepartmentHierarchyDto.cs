using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DepartmentHierarchyDto
    {
        public DepartmentDto? Department { get; set; }
        public List<DepartmentDto>? Children { get; set; }
        public List<DepartmentDto>? Parents { get; set; }
    }
}

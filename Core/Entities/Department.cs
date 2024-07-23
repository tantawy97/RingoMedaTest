﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public long? ParentDepartmentId { get; set; }
        public virtual Department? ParentDepartment { get; set; } 
        public virtual List<Department>? SubDepartments { get; set; }
    }
}

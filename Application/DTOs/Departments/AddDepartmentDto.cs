﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Departments
{
    public class AddDepartmentDto
    {
        public string Name { get; set; } = null!;
        public IFormFile Logo { get; set; } = null!;
        public long? ParentDepartmentId { get; set; }
    }
}

﻿using Application.DTOs.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IService
{
    public interface IDepartmentService
    {
        Task<DepartmentHierarchyDto> GetDepartmentHierarchyAsync(long startId);
        Task<List<DepartmentDto>> GetAllAsync();
        Task AddAsync(AddDepartmentDto departmentDto);
    }
}

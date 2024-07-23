using Application.DTOs.Departments;
using Application.Interfaces.IService;
using Application.Interfaces.IUnit;
using AutoMapper;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DepartmentHierarchyDto> GetDepartmentHierarchyAsync(long departmentId)
        {
          var departments = await  _unitOfWork.Department.GetById(departmentId);
            DepartmentHierarchyDto departmentHierarchy = new()
            {
                Department = _mapper.Map<DepartmentDto>(departments.Item1),
                Children = _mapper.Map<List<DepartmentDto>>(departments.Item1.SubDepartments),
                Parents = _mapper.Map<List<DepartmentDto>>(departments.Item2)
            };
            return departmentHierarchy;
        }

    }
}


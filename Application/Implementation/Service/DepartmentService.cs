using Application.DTOs.Departments;
using Application.Interfaces.IService;
using Application.Interfaces.IUnit;
using Application.Interfaces.IUtility;
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
        private readonly IFileUtility _fileUtility;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper, IFileUtility fileUtility)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileUtility = fileUtility;
        }
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
         return _mapper.Map<List<DepartmentDto>>(await _unitOfWork.Department.GetAllAsync());
        }  
        public async Task AddAsync(AddDepartmentDto departmentDto)
        {
            Department department = new()
            {
                Name = departmentDto.Name,
                Logo = await _fileUtility.SaveImage(departmentDto.Logo, "Department"),
                ParentDepartmentId = departmentDto.ParentDepartmentId,
            };
            await _unitOfWork.Department.AddAsync(department);
            await _unitOfWork.Save();
        }

        public async Task<DepartmentHierarchyDto> GetDepartmentHierarchyAsync(long departmentId)
        {
          var departments = await  _unitOfWork.Department.GetByIdAsync(departmentId);
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


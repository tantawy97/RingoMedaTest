using Application.DTOs.Departments;
using Application.Interfaces.IService;
using Application.Interfaces.IUnit;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RingoMediaTest.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _service;
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper, IDepartmentService service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _unitOfWork.Department.GetAllAsync();

            return View(_mapper.Map<List<DepartmentDto>>(departments));
        }  
        public async Task<IActionResult> Details(long id)
        {
            var department = await _service.GetDepartmentHierarchyAsync(id);

            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new AddDepartmentDto());
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddDepartmentDto addDepartment)
        {
            if(!ModelState.IsValid)
            {
                return View(addDepartment);
            }
            var department = _mapper.Map<Department>(addDepartment);
            await _unitOfWork.Department.AddAsync(department);
            await _unitOfWork.Save();
            return View(new AddDepartmentDto());
        }
    }
}

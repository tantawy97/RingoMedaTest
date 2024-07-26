using Application.DTOs.Departments;
using Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace RingoMediaTest.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _service.GetAllAsync();

            return View(departments);
        }
        public async Task<IActionResult> Details(long id)
        {
            var department = await _service.GetDepartmentHierarchyAsync(id);

            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments =await GetDepartmentList();
            return View(new AddDepartmentDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddDepartmentDto addDepartment)
        {
            ViewBag.Departments =await GetDepartmentList();
            if (!ModelState.IsValid)
            {
                return View(addDepartment);
            }
            await _service.AddAsync(addDepartment);
            return RedirectToAction("Index");
        }
        private async Task<List<DepartmentDto>> GetDepartmentList()
        {
            return await _service.GetAllAsync();
        }
    }
}

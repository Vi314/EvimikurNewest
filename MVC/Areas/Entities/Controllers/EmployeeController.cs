using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IDealerService _dealerService;
        private readonly IEmployeeMapper _mapper;

        public EmployeeController(IEmployeeService service, IDealerService dealerService, IEmployeeMapper mapper)
        {
            _service = service;
            _dealerService = dealerService;
            _mapper = mapper;
        }

        public IActionResult CreateEmployee()
        {
            var dealers = _dealerService.GetDealers().ToList();
            ViewBag.Dealers = dealers;
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDTO employeeDTO)
        {
            var dealers = _dealerService.GetDealers().ToList();
            ViewBag.Dealers = dealers;
            if (!ModelState.IsValid)
            {               
                return View(employeeDTO);
            }
            var employee = _mapper.ToEmployee(employeeDTO, dealers);
            var result = _service.CreateEmployee(employee);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var employees = _service.GetEmployees();
            var dealers = _dealerService.GetDealers().ToList();
            List<EmployeeDTO> dtoEmployees = new List<EmployeeDTO>();

            foreach (var emp in employees)
            {
                dtoEmployees.Add(_mapper.FromEmployee(emp, dealers));
            }

            return View(dtoEmployees);
        }
        public IActionResult UpdateEmployee(int id)
        {
            var dealers = _dealerService.GetDealers().ToList();
            var employee = _service.GetById(id);
            var employeeDTO = _mapper.FromEmployee(employee, dealers);
            ViewBag.Dealers = dealers;
            return View(employeeDTO);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var dealers = _dealerService.GetDealers().ToList();
            ViewBag.Dealers = dealers;
            if (!ModelState.IsValid)
            {
                return View(employeeDTO);
            }
            var employee = _mapper.ToEmployee(employeeDTO, dealers);
            var result = _service.UpdateEmployee(employee);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var result = _service.DeleteEmployee(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
    }
}

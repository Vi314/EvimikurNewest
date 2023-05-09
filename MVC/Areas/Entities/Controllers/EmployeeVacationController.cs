using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class EmployeeVacationController : Controller
	{
		private readonly IEmployeeVacationService _service;
		private readonly IEmployeeVacationMapper _mapper;
		private readonly IEmployeeService _employeeService;

		public EmployeeVacationController(IEmployeeVacationService service,IEmployeeVacationMapper mapper,IEmployeeService employeeService)
        {
			_service = service;
			_mapper = mapper;
			_employeeService = employeeService;
		}
        public IActionResult Index()
		{
			var employees = _employeeService.GetEmployees();
			var vacations = _service.GetEmployeeVacation();
			var vacationDtos = new List<EmployeeVacationDTO>();
			foreach (var item in vacations)
			{
				vacationDtos.Add(_mapper.FromEmployeeVacation(item, employees.ToList()));
			};
			return View(vacationDtos);
		}
        public IActionResult CreateEmployeeVacation()
        {
            EmployeeVacationDTO temp = new();
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            return View(temp);
        }
        [HttpPost]
        public IActionResult CreateEmployeeVacation(EmployeeVacationDTO employeeVacationDto)
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            var employeeVacation = _mapper.ToEmployeeVacation(employeeVacationDto, employees.ToList());
            var result = _service.CreateEmployeeVacation(employeeVacation);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployeeVacation(int id)
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            var employeeVacation = _service.GetById(id);
            var employeeVacationDto = _mapper.FromEmployeeVacation(employeeVacation, employees.ToList());
            return View(employeeVacationDto);
        }
        [HttpPost]
        public IActionResult UpdateEmployeeVacation(EmployeeVacationDTO employeeVacationDto)
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            var employeeVacation = _mapper.ToEmployeeVacation(employeeVacationDto, employees.ToList());
            var result = _service.UpdateEmployeeVacation(employeeVacation);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployeeVacation(int id)
        {
            var result = _service.DeleteEmployeeVacation(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
    }
}

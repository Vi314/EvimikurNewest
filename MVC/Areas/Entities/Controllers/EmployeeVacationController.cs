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
			var vacations = _service.GetEmployeeVacation().ToList();
			var vacationDtos = new List<EmployeeVacationDTO>();
			foreach (var item in vacations)
			{
				vacationDtos.Add(_mapper.FromEntity(item));
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
            if (!ModelState.IsValid)
            {
                var employees = _employeeService.GetEmployees();
                ViewBag.Employees = employees;
                return View(employeeVacationDto);
            }
            var employeeVacation = _mapper.FromDto(employeeVacationDto);
            var result = _service.CreateOne(employeeVacation);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployeeVacation(int id)
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            var employeeVacation = _service.GetById(id);
            var employeeVacationDto = _mapper.FromEntity(employeeVacation);
            return View(employeeVacationDto);
        }
        [HttpPost]
        public IActionResult UpdateEmployeeVacation(EmployeeVacationDTO employeeVacationDto)
        {
            if (!ModelState.IsValid)
            {
                var employees = _employeeService.GetEmployees();
                ViewBag.Employees = employees;
                return View(employeeVacationDto);
            }
            var employeeVacation = _mapper.FromDto(employeeVacationDto);
            var result = _service.UpdateOne(employeeVacation);
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

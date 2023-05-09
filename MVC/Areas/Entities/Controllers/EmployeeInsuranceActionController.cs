using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
    public class EmployeeInsuranceActionController : Controller
	{
        private readonly IEmployeeInsuranceActionService _service;
        private readonly IEmployeeInsuranceActionMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeeInsuranceActionController(IEmployeeInsuranceActionService service, IEmployeeInsuranceActionMapper mapper,IEmployeeService employeeService)
        {
            _service = service;
            _mapper = mapper;
            _employeeService = employeeService;
        }
        public IActionResult Index()
		{
            var employees = _employeeService.GetEmployees();
            var empActions = _service.GetEmployeeInsuranceActions();
            var empActionDtos = new List<EmployeeInsuranceActionDTO>();
            foreach (var item in empActions)
            {
                empActionDtos.Add(_mapper.FromEmployeeInsuranceAction(item, employees.ToList()));
            };
			return View(empActionDtos);
		}
        public IActionResult CreateEmployeeInsurance() 
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            EmployeeInsuranceActionDTO empActionDto = new();
            return View(empActionDto);
        }
        [HttpPost]
        public IActionResult CreateEmployeeInsurance(EmployeeInsuranceActionDTO empActionDTO)
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            if (!ModelState.IsValid)
            {
                return View(empActionDTO);
            }
            var empAction = _mapper.ToEmployeeInsuranceAction(empActionDTO, employees.ToList());
            var result = _service.CreateEmployeeInsuranceAction(empAction);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployeeInsurance(int id)
        {
            EmployeeInsuranceActionDTO empActionDto = new();
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            return View(empActionDto);
        }
        [HttpPost] 
        public IActionResult UpdateEmployeeInsurance(EmployeeInsuranceActionDTO empActionDTO)
        {
            var employees = _employeeService.GetEmployees();
            ViewBag.Employees = employees;
            if (!ModelState.IsValid)
            {
                return View(empActionDTO);
            }
            var empAction = _mapper.ToEmployeeInsuranceAction(empActionDTO, employees.ToList());
            var result = _service.UpdateEmployeeInsuranceAction(empAction);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployeeInsurance(int id)
        {
            var result = _service.DeleteEmployeeInsuranceAction(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
    }
}

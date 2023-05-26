using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeeYearlyVacationController : Controller
    {
        private readonly IEmployeeYearlyVacationService _service;
        private readonly IEmployeeYearlyVacationMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeeYearlyVacationController(IEmployeeYearlyVacationService service, IEmployeeYearlyVacationMapper mapper,IEmployeeService employeeService)
        {
            _service = service;
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            var yearlyVacations = _service.GetAll();
            var yearlyVacationDtos = new List<EmployeeYearlyVacationDTO>();
            foreach (var item in yearlyVacations)
            {
                yearlyVacationDtos.Add(_mapper.FromEntity(item));
            }
            return View(yearlyVacationDtos);
        }
        public IActionResult CalculateAll()
        {
            _service.CalculateAll();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            TempData["Result"] = _service.DeleteOne(id);
            return RedirectToAction("Index");
        }

    }
}

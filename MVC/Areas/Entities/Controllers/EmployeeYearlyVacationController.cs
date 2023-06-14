using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeeYearlyVacationController : BaseDashboardController<EmployeeYearlyVacationModel, IEmployeeYearlyVacationService, EmployeeYearlyVacationDto, IEmployeeYearlyVacationMapper>
    {
        private readonly IEmployeeYearlyVacationService _service;
        private readonly IEmployeeYearlyVacationMapper _mapper;

        public EmployeeYearlyVacationController(IEmployeeYearlyVacationService service, IEmployeeYearlyVacationMapper mapper) : base (service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult CalculateAll()
        {
            _service.CalculateAll();
            return RedirectToAction("Index");
        }

    }
}
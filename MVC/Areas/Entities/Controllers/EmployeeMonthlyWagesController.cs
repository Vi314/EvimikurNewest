using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeeMonthlyWagesController : BaseDashboardController<EmployeeMonthlyWagesModel, IEmployeeMonthlyWagesService, EmployeeMonthlyWagesDto, IEmployeeMonthlywagesMapper>
    {
        private readonly IEmployeeMonthlyWagesService _service;
        private readonly IEmployeeMonthlywagesMapper _mapper;

        public EmployeeMonthlyWagesController(IEmployeeMonthlyWagesService service, IEmployeeMonthlywagesMapper mapper) : base (service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
    }
}
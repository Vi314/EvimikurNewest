using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeeController : BaseDashboardController<EmployeeModel, IEmployeeService, EmployeeDto, IEmployeeMapper>
    {
        private readonly IEmployeeService _service;
        private readonly IDealerService _dealerService;
        private readonly IEmployeeMapper _mapper;

        public EmployeeController(IEmployeeService service, IDealerService dealerService, IEmployeeMapper mapper) : base(service, mapper)
        {
            _service = service;
            _dealerService = dealerService;
            _mapper = mapper;
        }

        public override void PopulateData()
        {
            ViewBag.Dealers = _dealerService.GetAll().ToList();
        }
        
    }
}
using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class EmployeePaymentsController : BaseDashboardController<EmployeePaymentsModel, IEmployeePaymentsService, EmployeePaymentsDto, IEmployeePaymentsMapper>
    {
        private readonly IEmployeePaymentsService _service;

        public EmployeePaymentsController(IEmployeePaymentsService service, IEmployeePaymentsMapper mapper) : base (service, mapper)
        {
            _service = service;
        }
        
    }
}
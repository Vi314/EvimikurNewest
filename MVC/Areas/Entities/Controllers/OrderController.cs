using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class OrderController : BaseDashboardController<OrderModel, IOrderService, OrderDto, IOrderMapper>
    {
        private readonly IOrderService _service;
        private readonly IOrderMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly IDealerService _dealerService;
        private readonly ISupplierService _supplierService;

        public OrderController(IOrderService service, IOrderMapper mapper, IEmployeeService employeeService, IDealerService dealerService, ISupplierService supplierService) : base (service, mapper)
        {
            _service = service;
            _mapper = mapper;
            _employeeService = employeeService;
            _dealerService = dealerService;
            _supplierService = supplierService;
        }

        public override void PopulateData()
        {
            ViewBag.Dealers = _dealerService.GetAll().ToList();
            ViewBag.Employees = _employeeService.GetAll().ToList();
            ViewBag.Suppliers = _supplierService.GetAll().ToList();
        }

    }
}
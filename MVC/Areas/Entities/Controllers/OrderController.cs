using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class OrderController : Controller
	{
		private readonly IOrderService _repository;
		private readonly IOrderMapper _orderMapper;
		private readonly IEmployeeService _employeeService;
		private readonly IDealerService _dealerService;
        private readonly ISupplierService _supplierService;

        public OrderController(IOrderService repository,IOrderMapper orderMapper,IEmployeeService employeeService,IDealerService dealerService,ISupplierService supplierService)
		{
			_repository = repository;
			_orderMapper = orderMapper;
			_employeeService = employeeService;
			_dealerService = dealerService;
            _supplierService = supplierService;
        }
		public IActionResult Index()
		{
			var suppliers = _supplierService.GetSuppliers();
			var orders = _repository.GetOrders();
			var dealers = _dealerService.GetDealers();
			var employees = _employeeService.GetEmployees();
			var orderDTOs = new List<OrderDTO>();
			foreach (var item in orders)
			{
				if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
				{
					orderDTOs.Add(_orderMapper.FromOrder(item, employees, dealers, suppliers));
				}
			}
			return View(orderDTOs);
		}
		public IActionResult CreateOrder()
		{
			OrderDTO orderDTO = new();
			ViewBag.Dealers = _dealerService.GetDealers();
			ViewBag.Employees = _employeeService.GetEmployees();
			ViewBag.Suppliers = _supplierService.GetSuppliers();
			return View(orderDTO);
		}
		[HttpPost]
        public IActionResult CreateOrder(OrderDTO orderDTO)
        {
			var suppliers = _supplierService.GetSuppliers();
            var dealers = _dealerService.GetDealers();
            var employees = _employeeService.GetEmployees();
			var order = _orderMapper.ToOrder(orderDTO, employees, dealers, suppliers);
            var result = _repository.CreateOrder(order);
			TempData["Result"] = result;
			return RedirectToAction("Index");
        }
        public IActionResult UpdateOrder(int id)
        {
			var suppliers = _supplierService.GetSuppliers();
            var dealers = _dealerService.GetDealers();
            var employees = _employeeService.GetEmployees();
            var order = _repository.GetById(id);
			var orderDTO = _orderMapper.FromOrder(order, employees, dealers, suppliers);
            ViewBag.Dealers = _dealerService.GetDealers();
            ViewBag.Employees = _employeeService.GetEmployees();
			ViewBag.Suppliers = _supplierService.GetSuppliers();
            return View(orderDTO);
        }
        [HttpPost]
        public IActionResult UpdateOrder(OrderDTO orderDTO)
        {
			var suppliers = _supplierService.GetSuppliers();
            var dealers = _dealerService.GetDealers();
            var employees = _employeeService.GetEmployees();
            var order = _orderMapper.ToOrder(orderDTO, employees, dealers, suppliers);
            var result = _repository.UpdateOrder(order);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteOrder(int id)
		{
			var result = _repository.DeleteOrder(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
		}
	}
}

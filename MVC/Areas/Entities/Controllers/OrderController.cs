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

        public OrderController(IOrderService repository, IOrderMapper orderMapper, IEmployeeService employeeService, IDealerService dealerService, ISupplierService supplierService)
        {
            _repository = repository;
            _orderMapper = orderMapper;
            _employeeService = employeeService;
            _dealerService = dealerService;
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            var orders = _repository.GetOrders();
            var orderDTOs = new List<OrderDTO>();
            foreach (var item in orders)
            {
                if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted && item.OrderType == Entity.Enum.OrderType.Customer)
                {
                    orderDTOs.Add(_orderMapper.FromEntity(item));
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
            ViewBag.Dealers = _dealerService.GetDealers();
            ViewBag.Employees = _employeeService.GetEmployees();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            if (!ModelState.IsValid)
            {
                return View(orderDTO);
            }
            var order = _orderMapper.FromDto(orderDTO);
            var result = _repository.CreateOne(order);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult UpdateOrder(int id)
        {
            var order = _repository.GetById(id);
            var orderDTO = _orderMapper.FromEntity(order);
            ViewBag.Dealers = _dealerService.GetDealers();
            ViewBag.Employees = _employeeService.GetEmployees();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            return View(orderDTO);
        }

        [HttpPost]
        public IActionResult UpdateOrder(OrderDTO orderDTO)
        {
            ViewBag.Dealers = _dealerService.GetDealers();
            ViewBag.Employees = _employeeService.GetEmployees();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            if (!ModelState.IsValid)
            {
                return View(orderDTO);
            }
            var order = _orderMapper.FromDto(orderDTO);
            var result = _repository.UpdateOne(order);
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
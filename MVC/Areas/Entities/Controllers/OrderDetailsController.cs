using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;
using static NuGet.Packaging.PackagingConstants;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class OrderDetailsController : Controller
	{
		private readonly IOrderDetailsService _repository;
        private readonly IOrderDetailsMapper _orderDetailsMapper;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderDetailsController(IOrderDetailsService repository,IOrderDetailsMapper orderDetailsMapper, IProductService productService,IOrderService orderService)
		{
			_repository = repository;
            _orderDetailsMapper = orderDetailsMapper;
            _productService = productService;
            _orderService = orderService;
        }
		public IActionResult Index()
		{
			var products = _productService.GetProducts();
			var orderDetails = _repository.GetOrderDetails();
			var orderDetailsDTO = new List<OrderDetailsDTO>();
			foreach (var item in orderDetails)
			{
				if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
				{
					orderDetailsDTO.Add(_orderDetailsMapper.FromOrderDetails(item,products));
				}
			}
			return View(orderDetailsDTO);
        }
        public IActionResult CreateOrderDetails()
        {
			var products = _productService.GetProducts();
            var orders = _orderService.GetOrders();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
			OrderDetailsDTO orderDetailsDTO = new();
            return View(orderDetailsDTO);
        }
		[HttpPost]
        public IActionResult CreateOrderDetails(OrderDetailsDTO orderDetailsDTO)
        {
			var products = _productService.GetProducts();
            var orders = _orderService.GetOrders();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            if (!ModelState.IsValid)
            {
                return View(orderDetailsDTO);
            }
            var orderDetails = _orderDetailsMapper.ToOrderDetails(orderDetailsDTO,products); 
            var result = _repository.CreateOrderDetails(orderDetails);
			TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult UpdateOrderDetails(int id)
        {
            var orders = _orderService.GetOrders();
            var products = _productService.GetProducts();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            var orderDetail = _repository.GetById(id);
			var orderDetailsDTO = _orderDetailsMapper.FromOrderDetails(orderDetail,products);
            return View(orderDetailsDTO);
        }
		[HttpPost]
        public IActionResult UpdateOrderDetails(OrderDetailsDTO orderDetailsDTO)	
		{

            var products = _productService.GetProducts();
            var orders = _orderService.GetOrders();
            ViewBag.Orders = orders;
            ViewBag.Products = products;
            if (!ModelState.IsValid)
            {
                return View(orderDetailsDTO);
            }
            var orderDetails = _orderDetailsMapper.ToOrderDetails(orderDetailsDTO, products);
            var result = _repository.UpdateOrderDetails(orderDetails);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
		public IActionResult DeleteOrderDetails(int id)
		{
			var result = _repository.DeleteOrderDetails(id);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
	}
}

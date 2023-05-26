using Logic.Abstract_Service;
using Logic.Concrete_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class SaleController : Controller
	{
		private readonly ISaleService _saleService;
		private readonly ISaleMapper _saleMapper;
		private readonly IDealerService _dealerService;
		private readonly IProductService _productService;
		private readonly ISalesAndDealersService _salesAndDealersService;

		public SaleController(ISaleService saleService,
							  ISaleMapper saleMapper,
							  IDealerService dealerService,
							  IProductService productService,
							  ISalesAndDealersService salesAndDealersService
			)
		{
			_saleService = saleService;
			_saleMapper = saleMapper;
			_dealerService = dealerService;
			_productService = productService;
			_salesAndDealersService = salesAndDealersService;
		}

		public IActionResult Index()
		{
			var sales = _saleService.GetAll();
			var saleDTOs = new List<SaleDTO>();
			foreach (var item in sales)
			{
				saleDTOs.Add(_saleMapper.FromEntity(item));
			}
			return View(saleDTOs);
		}
		public IActionResult Create()
		{
			ViewBag.Dealers = _dealerService.GetDealers();
			ViewBag.Products = _productService.GetProducts();
			return View(new SaleDTO());
		}
		[HttpPost]
		public IActionResult Create(SaleDTO saleDTO)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Dealers = _dealerService.GetDealers();
				ViewBag.Products = _productService.GetProducts();
				return View(saleDTO);
			}
			var sale = _saleMapper.FromDto(saleDTO);
			TempData["Result"] = _saleService.CreateOne(sale, saleDTO.Dealerids, saleDTO.Productids);
			return RedirectToAction("Index");
		}
		public IActionResult Update(int id)
		{
			ViewBag.Dealers = _dealerService.GetDealers();
			ViewBag.Products = _productService.GetProducts();
			var sale = _saleService.GetById(id);
			var saleDto = _saleMapper.FromEntity(sale);
			var salesAndDealers = _salesAndDealersService.GetAll(saleDto.Id).ToList();
			saleDto.Dealerids = new List<int>();
			foreach (var item in salesAndDealers)
			{
				saleDto.Dealerids.Add(item.DealerId);
			}
			return View(saleDto);
		}
		[HttpPost]
		public IActionResult Update(SaleDTO saleDTO)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Dealers = _dealerService.GetDealers();
				ViewBag.Products = _productService.GetProducts();
				return View(saleDTO);
			}
			var sale = _saleMapper.FromDto(saleDTO);
			TempData["Result"] = _saleService.UpdateOne(sale, saleDTO.Dealerids, new List<int>());
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			TempData["Result"] = _saleService.DeleteOne(id);
			return RedirectToAction("Index");
		}

	}
}

using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class DealerStocksController : Controller
	{
		private readonly IDealerStocksService _repository;
		private readonly IDealerStocksMapper _mapper;
		private readonly IProductService _productService;
		private readonly IDealerService _dealerService;
		private readonly IStockTransferMapper _transferMapper;
		private readonly ISupplierService _supplierService;

		public DealerStocksController(
			IDealerStocksService repository,
			IDealerStocksMapper mapper,
			IProductService productService,
			IDealerService dealerService,
			IStockTransferMapper transferMapper,
			ISupplierService supplierService)
		{
			_repository = repository;
			_mapper = mapper;
			_productService = productService;
			_dealerService = dealerService;
			_transferMapper = transferMapper;
			_supplierService = supplierService;
		}

		public IActionResult Index()
		{
			var stocks = _repository.GetDealerStocks().ToList();
			var DTOstocks = new List<DealerStockDTO>();
			foreach (var item in stocks)
			{
				if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
				{
					DTOstocks.Add(_mapper.FromEntity(item));
				}
			}
			return View(DTOstocks);
		}

		public IActionResult TransferStock()
		{
			ViewBag.Dealers = _dealerService.GetDealers().ToList();
			ViewBag.Products = _productService.GetProducts().ToList();
			StockTransferDTO stockTransferDTO = new();
			return View(stockTransferDTO);
		}

		[HttpPost]
		public IActionResult TransferStock(StockTransferDTO stockTransferDTO)
		{
			var products = _productService.GetProducts().ToList();
			var dealers = _dealerService.GetDealers().ToList();
			var stockTransferObject = _transferMapper.ToStockTransferObject(stockTransferDTO, products, dealers);
			var result = _repository.TransferStock(stockTransferObject);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}

		public IActionResult CreateStock()
		{
			var dealerStockDTO = new DealerStockDTO();
			ViewBag.Dealers = _dealerService.GetDealers().ToList();
			ViewBag.Products = _productService.GetProducts().ToList();
			ViewBag.Suppliers = _supplierService.GetSuppliers().ToList();
			return View(dealerStockDTO);
		}

		[HttpPost]
		public IActionResult CreateStock(DealerStockDTO dealerStockDTO)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Dealers = _dealerService.GetDealers().ToList();
				ViewBag.Products = _productService.GetProducts().ToList();
				ViewBag.Suppliers = _supplierService.GetSuppliers().ToList();
				return View(dealerStockDTO);
			}
			var dealerStocks = _mapper.FromDto(dealerStockDTO);
			var result = _repository.CreateOne(dealerStocks);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}

		public IActionResult UpdateStock(int id)
		{
			var stock = _repository.GetById(id);
			ViewBag.Dealers = _dealerService.GetDealers().ToList();
			ViewBag.Products = _productService.GetProducts().ToList();
			ViewBag.Suppliers = _supplierService.GetSuppliers().ToList();
			var dealerStocksDTO = _mapper.FromEntity(stock);
			return View(dealerStocksDTO);
		}

		[HttpPost]
		public IActionResult UpdateStock(DealerStockDTO dealerStocksDTO)
		{
			if (!ModelState.IsValid)
			{ 
				ViewBag.Dealers = _dealerService.GetDealers().ToList();
				ViewBag.Products = _productService.GetProducts().ToList();
				ViewBag.Suppliers = _supplierService.GetSuppliers().ToList();
				return View(dealerStocksDTO);
			}
			var dealerStocks = _mapper.FromDto(dealerStocksDTO);
			var result = _repository.UpdateOne(dealerStocks);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}

		public IActionResult DeleteStock(int id)
		{
			var result = _repository.DeleteDealerStocks(id);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}
	}
}
using Entity.Entity;
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
			var stocks = _repository.GetDealerStocks();
			var DTOstocks = new List<DealerStockDTO>();
			var dealers = _dealerService.GetDealers();
			var products = _productService.GetProducts();
			var suppliers = _supplierService.GetSuppliers();
			foreach (var item in stocks)
			{
				if (item.State != Microsoft.EntityFrameworkCore.EntityState.Deleted)
				{
					DTOstocks.Add(_mapper.FromDealerStock(item));
				}
			}
			return View(DTOstocks);
		}

		public IActionResult TransferStock()
		{
			ViewBag.Dealers = _dealerService.GetDealers();
			ViewBag.Products = _productService.GetProducts();
			StockTransferDTO stockTransferDTO = new();
			return View(stockTransferDTO);
		}
		[HttpPost]
        public IActionResult TransferStock(StockTransferDTO stockTransferDTO)
        {
			var products = _productService.GetProducts();
			var dealers = _dealerService.GetDealers();
            var stockTransferObject = _transferMapper.ToStockTransferObject(stockTransferDTO, products, dealers);
			var result = _repository.TransferStock(stockTransferObject);
			TempData["Result"] = result;
            return RedirectToAction("Index");
        }

        public IActionResult CreateStock() 
		{
			var dealerStockDTO = new DealerStockDTO();
			ViewBag.Dealers = _dealerService.GetDealers();
			ViewBag.Products = _productService.GetProducts();
			ViewBag.Suppliers = _supplierService.GetSuppliers();
			return View(dealerStockDTO);
		}
		[HttpPost]
		public IActionResult CreateStock(DealerStockDTO dealerStockDTO) 
		{
            if (!ModelState.IsValid)
            {
                var products = _productService.GetProducts();
                var dealers = _dealerService.GetDealers();
                var suppliers = _supplierService.GetSuppliers();
                ViewBag.Dealers = _dealerService.GetDealers();
                ViewBag.Products = _productService.GetProducts();
                ViewBag.Suppliers = _supplierService.GetSuppliers();
                return View(dealerStockDTO);
            }
            var dealerStocks = _mapper.ToDealerStock(dealerStockDTO);
			var result = _repository.CreateOne(dealerStocks);
			TempData["Result"] = result;
			return RedirectToAction("Index");
		}

		public IActionResult UpdateStock(int id) 
		{
			var stock = _repository.GetById(id);
			var products = _productService.GetProducts();
			var dealers = _dealerService.GetDealers();
            var suppliers = _supplierService.GetSuppliers();
            ViewBag.Dealers = _dealerService.GetDealers();
			ViewBag.Products = _productService.GetProducts();
            ViewBag.Suppliers = _supplierService.GetSuppliers();
            var dealerStocksDTO = _mapper.FromDealerStock(stock);
			return View(dealerStocksDTO);
		}
		[HttpPost]
		public IActionResult UpdateStock(DealerStockDTO dealerStocksDTO)
		{
            if (!ModelState.IsValid)
            {
                var products = _productService.GetProducts();
                var dealers = _dealerService.GetDealers();
                var suppliers = _supplierService.GetSuppliers();
                ViewBag.Dealers = _dealerService.GetDealers();
                ViewBag.Products = _productService.GetProducts();
                ViewBag.Suppliers = _supplierService.GetSuppliers();
                return View(dealerStocksDTO);
            }
            var dealerStocks = _mapper.ToDealerStock(dealerStocksDTO);
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

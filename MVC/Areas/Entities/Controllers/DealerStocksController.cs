using Entity.Base;
using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class DealerStocksController : BaseDashboardController<DealerStocksModel, IDealerStocksService, DealerStockDTO, IDealerStocksMapper>
    {
        private readonly IDealerStocksService _service;
        private readonly IDealerStocksMapper _mapper;
        private readonly IProductService _productService;
        private readonly IDealerService _dealerService;
        private readonly IStockTransferMapper _transferMapper;
        private readonly ISupplierService _supplierService;
        
        public DealerStocksController(
            IDealerStocksService service,
            IDealerStocksMapper mapper,
            IProductService productService,
            IDealerService dealerService,
            IStockTransferMapper transferMapper,
            ISupplierService supplierService) 
            : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
            _productService = productService;
            _dealerService = dealerService;
            _transferMapper = transferMapper;
            _supplierService = supplierService;
        }

        public override void PopulateData()
        {
            ViewBag.Dealers = _dealerService.GetAll().ToList();
            ViewBag.Products = _productService.GetAll().ToList();
            ViewBag.Suppliers = _supplierService.GetAll().ToList();
        }
        
        public IActionResult TransferStock()
        {
            PopulateData();
            StockTransferDTO stockTransferDTO = new();
            return View(stockTransferDTO);
        }

        [HttpPost]
        public IActionResult TransferStock(StockTransferDTO stockTransferDTO)
        {
            var products = _productService.GetAll().ToList();
            var dealers = _dealerService.GetAll().ToList();
            var stockTransferObject = _transferMapper.ToStockTransferObject(stockTransferDTO, products, dealers);
            var result = _service.TransferStock(stockTransferObject);
            TempData["Result"] = result;
            return RedirectToAction("Index");
        }
        
    }
}
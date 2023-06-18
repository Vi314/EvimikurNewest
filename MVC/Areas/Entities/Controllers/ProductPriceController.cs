using Entity.Entity;
using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.BaseControllers;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class ProductPriceController : BaseDashboardController<ProductPriceModel, IProductPriceService, ProductPriceDto, IProductPriceMapper>
    {
        private readonly IProductPriceService _service;
        private readonly IProductService _productService;
        private readonly IDealerService _dealerService;
        private readonly IProductPriceMapper _mapper;

        public ProductPriceController(IProductPriceService service,
                                      IProductService productService,
                                      IDealerService dealerService,
                                      IProductPriceMapper mapper) 
                                     : base (service, mapper)
        {
            _service = service;
            _productService = productService;
            _dealerService = dealerService;
            _mapper = mapper;
        }

        public override void PopulateData() 
        {
            ViewBag.Dealers = _dealerService.GetAll().ToList();
            ViewBag.Products = _productService.GetAll().ToList();
        }
        
    }
}
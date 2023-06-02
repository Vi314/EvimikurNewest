using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class ProductPriceController : Controller
	{
		private readonly IProductPriceService _service;
		private readonly IProductService _productService;
		private readonly IDealerService _dealerService;
		private readonly IProductPriceMapper _mapper;

		public ProductPriceController(IProductPriceService service,
									  IProductService productService,
									  IDealerService dealerService,
									  IProductPriceMapper mapper)
        {
			_service = service;
			_productService = productService;
			_dealerService = dealerService;
			_mapper = mapper;
		}

        public IActionResult Index()
		{
			var prices = _service.GetAll().ToList();
			var pricesDto = new List<ProductPriceDto>();
			foreach (var i in prices)
			{
				pricesDto.Add(_mapper.FromEntity(i));
			}
			return View(pricesDto);
		}

		public IActionResult Create()
		{
			ViewBag.Products = _productService.GetProducts().ToList();
			return View(new ProductPriceDto());
		}
		[HttpPost]
		public IActionResult Create(ProductPriceDto dto)
		{
			if (!ModelState.IsValid)
			{
                ViewBag.Products = _productService.GetProducts().ToList();
                return View(dto);
			}
			var model = _mapper.FromDto(dto);
			var result = _service.CreateOne(model);
			return RedirectToAction("Index");
		}

		public IActionResult Update(int id)
		{
			return View();
		}
		[HttpPost] 
		public IActionResult Update(ProductPriceDto dto)
		{
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			return RedirectToAction("Index");
		}

	}
}

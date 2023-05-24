using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class ProductPriceController : Controller
	{
		private readonly IProductPriceService _service;

		public ProductPriceController(IProductPriceService service)
        {
			_service = service;
		}
        public IActionResult Index()
		{
			return View();
		}
	}
}

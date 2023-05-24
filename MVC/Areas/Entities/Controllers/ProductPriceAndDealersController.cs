using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
	[Area("Entities")]
	public class ProductPriceAndDealersController : Controller
	{
		private readonly IProductPriceAndDealersService _service;

		public ProductPriceAndDealersController(IProductPriceAndDealersService service)
        {
			_service = service;
		}
        public IActionResult Index()
		{
			return View();
		}
	}
}

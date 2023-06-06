using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SalesAndProductsController : Controller
    {
        private readonly ISalesAndProductsService _service;

        public SalesAndProductsController(ISalesAndProductsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
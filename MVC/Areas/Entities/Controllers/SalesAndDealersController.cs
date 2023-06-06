using Logic.Abstract_Service;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    public class SalesAndDealersController : Controller
    {
        private readonly ISalesAndDealersService _service;

        public SalesAndDealersController(ISalesAndDealersService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    [Route("Entities/Home")]
    public class HomeController : Controller
    {
        [Route("/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
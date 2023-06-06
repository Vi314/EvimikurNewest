using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace MVC.Areas.Entities.Controllers
{
    [Area("Entities")]
    //[Authorize(Roles = "Admin, Dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Identity.Controllers;

[Area("Identity")]
public class AccountSettingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AccountSettingsController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult UpdateUser()
    {
        return View();
    }

}

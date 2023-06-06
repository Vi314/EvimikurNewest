using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Identity.Controllers;
[Area("Identity")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager,
                             SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult LogOut()
    {
        return View();
    }



    public IActionResult ValidateEmail()
    {
        return View();
    }

    public IActionResult LockedOut()
    {
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}

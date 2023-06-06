using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //! IDENTITY RELATED TASKS CARRIED TO 'Identity' AREA
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDTO loginDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(loginDto);
        //    }
        //    var user = await _userManager.FindByEmailAsync(loginDto.Email);

        //    if (user == null)
        //    {
        //        return View();
        //    }
        //    var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);

        //    if (!result.Succeeded)
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Index");
        //}

        public IActionResult Register()
        {
            return View();
        }

        //! IDENTITY RELATED TASKS CARRIED TO 'Identity' AREA
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDTO registerDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(registerDto);
        //    }

        //    IdentityUser user = new IdentityUser
        //    {
        //        UserName = registerDto.Username,
        //        Email = registerDto.Email,
        //    };

        //    var result = await _userManager.CreateAsync(user, registerDto.Password);

        //    if (!result.Succeeded)
        //    {
        //        return View(registerDto);
        //    }

        //    return RedirectToAction("Index");
        //}

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
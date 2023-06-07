using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Web.Helpers;
using System.Web;
using System.Net.Mail;
using System.Net;

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
    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO loginDto)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            TempData["Header"] = "Kullanıcı Yok!";
            return View(loginDto);
        }

        if (!user.EmailConfirmed)
        {
            TempData["Header"] = "E-Posta doğrulanmamış!";
            TempData["Body"] = "E-Postanızı kontrol edin";
            return View(loginDto);
        }

        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);

        if (!result.Succeeded)
        {
            return View();
        }
        return Redirect("/Home/Index");
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDTO registerDto)
    {
        if (!ModelState.IsValid)
        {
            return View(registerDto);
        }

        AppUser user = new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            return View(registerDto);
        }

        return Redirect("~/Home/Index");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("~/Home/Index");
    }

    public IActionResult SendConfirmationEmail()
    {
        // Initialize WebMail helper
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("evimikur123@outlook.com");
        mailMessage.To.Add("abdullaharslanvi@gmail.com");
        mailMessage.Subject = "Subject";
        mailMessage.Body = "TEST EMAIL MESSAGE";

        SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);

        smtpClient.Credentials = new NetworkCredential("evimikur123@outlook.com", "vz32kK88");
        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);
            
        
        return Redirect("/Home/Index");
    }

    //? TO ADD TOKEN FROM VALIDATION EMAIL THAT WAS SENT
    //TODO Integrate a system that will check for a Guid token that was sent by email
    [Route("/id/token")]
    public IActionResult EmailValidation()
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

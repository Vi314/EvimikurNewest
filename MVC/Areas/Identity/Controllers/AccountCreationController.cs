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
public class AccountCreationController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountCreationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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

        var user = new AppUser
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
        token = token.Replace("/", "slash");
        token = token.Replace("+", "plus");

        SendConfirmationEmail(user, token);

        if (!result.Succeeded)
        {
            return View(registerDto);
        }

        return Redirect("/Home/Index");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/Home/Index");
    }

    public IActionResult SendConfirmationEmail(AppUser user, string token)
    {
        // Initialize WebMail helper
        MailMessage mailMessage = new()
        {
            From = new MailAddress("evimikur123@outlook.com")
        };
        mailMessage.To.Add(user.Email ?? "");
        mailMessage.Subject = "Subject";
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = 
            $"<div class='container'><div class='row'>" +
            $"<h2>Evimikur E-Posta Doğrulama</h2><br /><hr /><br />" +
            $"<img src='https://pbs.twimg.com/media/EaFYbaxXsAMN2N1.jpg' style='height:300px;width:250px;'/><br />" +
            $"<span>Bu E-Posta EvimiKur sitesinde açmış olduğunuz '{user.UserName}' isimli hesabınızın doağrulanması için gönderilmiştir.</span><br /><br />" +
            $"<span>E-Postanızı doğrulamak için aşşağıda bulunan linke tıklayınız.</span><br />" +
            $"<span>Doğrulama Linki : <a href='http://localhost:5103/Validation/{user.Id}/{token} '>Doğrulama Linki</a> </span><br /></div></div>";

        SmtpClient smtpClient = new("smtp.office365.com", 587)
        {
            Credentials = new NetworkCredential("evimikur123@outlook.com", "vz32kK88"),
            EnableSsl = true
        };
        smtpClient.Send(mailMessage);

        return Redirect("/Home/Index");
    }

    [Route("/Validation/{id}/{token}")]
    public async Task<IActionResult> EmailValidation(int id, string token)
    {
        token = token.Replace("slash", "/");
        token = token.Replace("plus", "+");

        var user = _userManager.FindByIdAsync(id.ToString()).Result;
        if (user is null)
        {
            return View("Kullanıcı bulunamadı!");
        }
        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return View("Email doğrulanamadı!");
        }
        return View($"'{user.Email}' emailiniz '{user.UserName}' isimli hesabınız için doğrulandı!");
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

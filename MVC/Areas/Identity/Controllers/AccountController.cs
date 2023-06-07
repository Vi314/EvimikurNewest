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

        var token = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
        var thing = token.Where(x => x != '/' && x != '+').ToList();

        string finalToken = "";
        foreach (var _char in thing)
        {
            finalToken += _char.ToString();
        }

        SendConfirmationEmail(user, finalToken);

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
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("evimikur123@outlook.com");
        mailMessage.To.Add("abdullaharslanvi@gmail.com");
        mailMessage.Subject = "Subject";
        mailMessage.IsBodyHtml = true;
        mailMessage.Body =
            $"<div class='container'>" +
            $"<div class='row'>" +
            $"<h2>Evimikur E-Posta Doğrulama</h2><br />" +
            $"<hr /><br />" +
            $"<img src='https://pbs.twimg.com/media/EaFYbaxXsAMN2N1.jpg' style='height:300px;width:250px;'/><br />" +
            $"<span>Bu E-Posta EvimiKur sitesinde açmış olduğunuz '{user.UserName}' isimli hesabınızın doağrulanması için gönderilmiştir.</span><br /><br />" +
            $"<span>E-Postanızı doğrulamak için aşşağıda bulunan linke tıklayınız.</span><br />" +
            $"<span>Doğrulama Linki : <a href='http://localhost:5103/{user.Id}/{token} '>CLICK HERE</a> </span><br /></div></div>";

        SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587);
        smtpClient.Credentials = new NetworkCredential("evimikur123@outlook.com", "vz32kK88");
        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage);

        return Redirect("/Home/Index");
    }

    [Route("/{id}/{token}")]
    public IActionResult EmailValidation(int id, string token)
    {
        _userManager.ConfirmEmailAsync( , token);

        return Redirect("/Home/Index");
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

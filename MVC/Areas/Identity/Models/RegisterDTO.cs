using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Identity.Models
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public required string Username { get; set; }

        //Email
        [Required(ErrorMessage = "Email boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email adresi formatında olmalı!!!")]
        public required string Email { get; set; }

        //Password
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public required string Password { get; set; }

        //ConfirmPassword
        [Required(ErrorMessage = "Şifre (tekrar) boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public required string ConfirmPassword { get; set; }
    }
}
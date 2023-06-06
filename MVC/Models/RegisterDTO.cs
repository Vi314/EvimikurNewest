using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        //Email
        [Required(ErrorMessage = "Email boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email adresi formatında olmalı!!!")]
        public string Email { get; set; }

        //Password
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }

        //ConfirmPassword
        [Required(ErrorMessage = "Şifre (tekrar) boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
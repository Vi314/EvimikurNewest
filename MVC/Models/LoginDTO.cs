using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class LoginDTO
    {
        //Username
        [Required(ErrorMessage = "E-Posta boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email adresi formatında olmalı!!!")]
        public string Email { get; set; }

        //Password
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Identity.Models
{
    public class LoginDTO
    {
        //Username
        [Required(ErrorMessage = "E-Posta boş geçilemez!")]
        [EmailAddress(ErrorMessage = "Email adresi formatında olmalı!!!")]
        public required string Email { get; set; }

        //Password
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public required string Password { get; set; }
    }
}
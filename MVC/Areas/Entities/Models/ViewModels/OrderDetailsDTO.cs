using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDetailsDTO:BaseDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int OrderId { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? ProductName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int Amount { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public decimal Price { get; set; }
    }
}

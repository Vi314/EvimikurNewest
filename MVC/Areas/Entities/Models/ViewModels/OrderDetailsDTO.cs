using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels;

public class OrderDetailsDTO : BaseDto
{
    [Required(ErrorMessage = ErrorMessages.requiredField)]
    public int OrderId { get; set; }

    [Required(ErrorMessage = ErrorMessages.requiredField)]
    public string? ProductName { get; set; }

    [Required(ErrorMessage = ErrorMessages.requiredField)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = ErrorMessages.requiredField)]
    public int Amount { get; set; }

    [Required(ErrorMessage = ErrorMessages.requiredField)]
    public decimal Price { get; set; } 
}



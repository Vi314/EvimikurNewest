using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels;

public class OrderDetailsDto : BaseDto
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



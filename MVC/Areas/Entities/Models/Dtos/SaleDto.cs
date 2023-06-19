using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels;

public class SaleDto : BaseDto
{
    [Required]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Required]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, 99, ErrorMessage = "Değer 0 ile 100 arasında olmalı!")]
    public double Discount { get; set; }

    public List<int> Productids { get; set; } = new List<int>();
    public List<int> Dealerids { get; set; } = new List<int>();
    public bool IsForAllDealers { get; set; } = false;
    public bool IsForAllProducts { get; set; } = false;
}
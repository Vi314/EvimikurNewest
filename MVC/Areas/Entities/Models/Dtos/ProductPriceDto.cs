using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class ProductPriceDto : BaseDto
    {
        public string? ProductName { get; set; }
        public int ProductId { get; set; }
        public List<int> DealerIds { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public decimal ProductionPrice { get; set; }
        public double TaxPercentage { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }

        [Required]
        public DateTime ValidUntil { get; set; } = DateTime.Now.AddYears(1);
    }
}
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class ProductPriceDto:BaseDTO
	{
		public string? ProductName { get; set; }
		public int ProductId { get; set; }
        public string Description { get; set; }
		public decimal ProductionPrice { get; set; }
		public double TaxPercentage { get; set; }
		public decimal TaxPrice { get; set; }
		public decimal SellingPrice { get; set; }
		public int DiscountPercentage { get; set; }
		public decimal DiscountedPrice { get; set; }
		[Required]
		public string ValidUntil { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class DealerStockDTO:BaseDTO
	{
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? DealerName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? ProductName { get; set; }
        public int? MinimumAmount { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? SupplierName { get; set; }
		public decimal? Cost { get; set; }
		public decimal? SalesPrice { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? Amount { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class DealerStockDTO:BaseDTO
	{
        public string? DealerName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? DealerId { get; set; }

        public string? ProductName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? ProductId { get; set; }
        
       
        public string? SupplierName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? SupplierId { get; set; }

        public decimal? Cost { get; set; }
		public decimal? SalesPrice { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? Amount { get; set; }
        public int? MinimumAmount { get; set; }
    }
}

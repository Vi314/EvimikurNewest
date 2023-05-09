namespace MVC.Areas.Entities.Models.ViewModels
{
	public class DealerStockDTO:BaseDTO
	{
		public string? DealerName { get; set; }
		public string? ProductName { get; set; }
        public int? MinimumAmount { get; set; }
        public string? SupplierName { get; set; }
		public decimal? Cost { get; set; }
		public decimal? SalesPrice { get; set; }
		public int? Amount { get; set; }
	}
}

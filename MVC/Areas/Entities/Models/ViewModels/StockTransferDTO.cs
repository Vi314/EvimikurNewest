namespace MVC.Areas.Entities.Models.ViewModels
{
    public class StockTransferDTO
    {
        public string FromDealerName { get; set; }
        public string ToDealerName { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
    }
}

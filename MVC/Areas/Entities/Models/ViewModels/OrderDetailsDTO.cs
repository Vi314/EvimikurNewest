namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDetailsDTO:BaseDTO
    {
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}

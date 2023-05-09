namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDTO:BaseDTO
    {
        public string DealerName { get; set; }
        public string EmployeeName { get; set; }
        public string? SupplierName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

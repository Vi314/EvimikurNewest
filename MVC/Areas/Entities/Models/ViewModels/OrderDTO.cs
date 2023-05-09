using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDTO:BaseDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string DealerName { get; set; }
        public string EmployeeName { get; set; }
        public string? SupplierName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDTO:BaseDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string DealerName { get; set; }
        public int DealerId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string? SupplierName { get; set; }
        public int? SupplierId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderType OrderType { get; set; }
    }
}

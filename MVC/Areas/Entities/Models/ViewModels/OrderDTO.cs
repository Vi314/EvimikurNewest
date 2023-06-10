using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDTO : BaseDTO
    {
        public string DealerName { get; set; } = "";

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int DealerId { get; set; }

        public string EmployeeName { get; set; } = "";

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int EmployeeId { get; set; }

        public string? SupplierName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? SupplierId { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderType OrderType { get; set; }
    }
}
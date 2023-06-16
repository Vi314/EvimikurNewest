using Entity.Enum;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class OrderDto : BaseDto
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
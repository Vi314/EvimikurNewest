using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class SupplierContractDTO : BaseDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? SupplierName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? SupplierId { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime ContractSignDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime ContractEndDate { get; set; } = DateTime.Now.AddYears(1);

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime PaymentDate { get; set; } = DateTime.Now.AddMonths(1);

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public ContractState? ContractState { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? ProductId { get; set; }

        public decimal? Price { get; set; }
        public decimal? ShippingCost { get; set; }
        public int? Amount { get; set; }
    }
}
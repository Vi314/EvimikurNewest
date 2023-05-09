using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class SupplierContractDTO:BaseDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? SupplierName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public string? ContractSignDate { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public string? ContractEndDate { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public string? PaymentDate { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public ContractState? ContractState { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShippingCost { get; set; }
        public int? Amount { get; set; }
    }
}

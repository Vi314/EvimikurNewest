using Entity.Enum;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class SupplierContractDTO:BaseDTO
    {
        public string? SupplierName { get; set; }
        public string? ContractSignDate { get; set; }
        public string? ContractEndDate { get; set; }
        public string? PaymentDate { get; set; }
        public ContractState? ContractState { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShippingCost { get; set; }
        public int? Amount { get; set; }
    }
}

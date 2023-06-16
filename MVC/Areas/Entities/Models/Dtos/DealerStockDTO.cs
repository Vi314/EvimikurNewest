using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class DealerStockDTO : BaseDto
    {
        public string? DealerName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? DealerId { get; set; }

        public string? ProductName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? ProductId { get; set; }

        public string? SupplierName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? SupplierId { get; set; }

        public decimal? Cost { get; set; }
        public decimal? SalesPrice { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? Amount { get; set; }

        public int? MinimumAmount { get; set; }
    }
}
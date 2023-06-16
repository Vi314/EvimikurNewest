using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MVC.Areas.Entities.Models.Alerts_And_Messages;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class StockTransferDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string FromDealerName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string ToDealerName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string ProductName { get; set; } = string.Empty;

        public int Amount { get; set; }
    }
}
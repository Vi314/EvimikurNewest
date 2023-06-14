using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class SupplierDto : BaseDto
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? CompanyName { get; set; }

        [Range(0, 100, ErrorMessage = "Değer 0 ile 100 arasında olmalı!")]
        public int? SupplierGrade { get; set; }
        
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public ApprovalState? ApprovalState { get; set; }
    }
}
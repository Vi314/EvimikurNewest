using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class SupplierDTO : BaseDTO
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? CompanyName { get; set; }

        [Range(0, 100, ErrorMessage = "Değer 0 ile 100 arasında olmalı!")]
        public int? SupplierGrade { get; set; }

        public ApprovalState? ApprovalState { get; set; }
    }
}
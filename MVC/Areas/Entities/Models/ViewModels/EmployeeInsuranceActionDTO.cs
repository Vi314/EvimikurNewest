using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class EmployeeInsuranceActionDTO : BaseDTO
    {
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? EmployeeName { get; set; }

        public int? EmployeeId { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(255, ErrorMessage = ErrorMessages.toolong255)]
        public string? Hospital { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(2000, ErrorMessage = ErrorMessages.toolong2000)]
        public string? Operation { get; set; }
    }
}
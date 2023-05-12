using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class EmployeeVacationDTO:BaseDTO
	{
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? EmployeeName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime? VacationStart { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime? VacationEnd { get; set; }
		public int? VacationDuration { get; set; }
		public bool IsApproved { get; set; }
	}
}

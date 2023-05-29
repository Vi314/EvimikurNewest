using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class EmployeeVacationDTO:BaseDTO
    { 
        public string? EmployeeName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public string VacationStart { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public string VacationEnd { get; set; }
		public int? VacationDuration { get; set; }
		public bool IsApproved { get; set; }
	}
}

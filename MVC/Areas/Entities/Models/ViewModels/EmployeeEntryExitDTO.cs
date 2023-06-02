using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class EmployeeEntryExitDTO:BaseDTO
	{
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
		public int? EmployeeId { get; set; }

        public DateTime Entry { get; set; }
		public DateTime Exit { get; set; }
	}
}

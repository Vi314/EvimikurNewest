namespace MVC.Areas.Entities.Models.ViewModels
{
	public class EmployeeEntryExitDTO:BaseDTO
	{
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? EmployeeName { get; set; }
		public DateTime Entry { get; set; }
		public DateTime Exit { get; set; }
	}
}

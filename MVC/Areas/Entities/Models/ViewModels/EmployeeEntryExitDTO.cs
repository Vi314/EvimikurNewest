namespace MVC.Areas.Entities.Models.ViewModels
{
	public class EmployeeEntryExitDTO:BaseDTO
	{
		public string? EmployeeName { get; set; }
		public DateTime Entry { get; set; }
		public DateTime Exit { get; set; }
	}
}

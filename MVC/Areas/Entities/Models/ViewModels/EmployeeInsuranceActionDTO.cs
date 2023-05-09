namespace MVC.Areas.Entities.Models.ViewModels
{
	public class EmployeeInsuranceActionDTO:BaseDTO
	{
		public DateTime? Date { get; set; }
		public string? EmployeeName { get; set; }
		public string? Hospital { get; set; }
		public string? Operation { get; set; }
	}
}

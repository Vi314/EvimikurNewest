namespace MVC.Areas.Entities.Models.ViewModels
{
	public class SalesDTO:BaseDTO
	{
		public List<string>? ProductNames { get; set; }
		public List<string>? DealerNames { get; set; }
		public string? StartDate { get; set; }
		public string? EndDate { get; set; }
		public int? Duration { get; set; }

	}
}

namespace MVC.Areas.Entities.Models.ViewModels
{
	public class ProductDTO:BaseDTO
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Category { get; set; }
		public float? LooksGrade { get; set; }
		public float? UsabilityGrade { get; set; }
		public float? FunctionalityGrade { get; set; }
		public float? InnovativeGrade { get; set; }
		public float? PriceAdvantageGrade { get; set; }
		public float? PotentialSalesGrade { get; set; }

	}
}

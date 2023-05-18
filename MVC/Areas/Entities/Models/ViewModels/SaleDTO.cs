using Entity.Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class SaleDTO:BaseDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0, 100)]
        public double Discount { get; set; }
		public List<int> Productids { get; set; }
		public List<int> Dealerids { get; set; }
		public bool IsForAllDealers { get; set; } = false;
		public bool IsForAllProducts { get; set; } = false;
	}
}

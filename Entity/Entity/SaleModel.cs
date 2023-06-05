using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class SaleModel : BaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public double Discount { get; set; }

        public bool IsForAllDealers { get; set; } = false;
        public bool IsForAllProducts { get; set; } = false;
        public bool IsActive { get; set; } = false;

        public List<ProductModel> Products { get; set; }
        public List<DealerModel> Dealers { get; set; }
    }
}
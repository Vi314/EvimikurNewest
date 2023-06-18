using Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    public class DealerModel : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string? FullAdress { get; set; }
        
        [NotMapped]
        public List<ProductPriceModel> ProductPrices { get; set; } = new List<ProductPriceModel>();
        [NotMapped] 
        public List<SaleModel> Sales { get; set; } = new();
    }
}
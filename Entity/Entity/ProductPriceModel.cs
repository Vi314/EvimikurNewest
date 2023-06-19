using Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    public class ProductPriceModel : BaseEntity
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal ProductionPrice { get; set; }
        public double TaxPercentage { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public DateTime ValidUntil { get; set; }
        public ProductModel Product { get; set; }
        [NotMapped]
        public List<DealerModel> Dealers { get; set; }
    }
}
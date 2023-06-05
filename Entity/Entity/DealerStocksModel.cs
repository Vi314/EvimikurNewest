using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class DealerStocksModel : BaseEntity
    {
        [Required]
        public int? DealerId { get; set; }

        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int? SupplierId { get; set; }

        [Required]
        public int? Amount { get; set; }

        public int? MinimumAmount { get; set; }

        public decimal? Cost { get; set; }
        public decimal? SalesPrice { get; set; }

        public SupplierModel? Supplier { get; set; }

        [Required]
        public DealerModel? Dealer { get; set; }

        [Required]
        public ProductModel? Product { get; set; }
    }
}
using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class DealerStocks:BaseEntity
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

        public Supplier? Supplier { get; set; }
        [Required]
        public Dealer? Dealer { get; set; }
        [Required]
        public Product? Product { get; set; }

    }
}

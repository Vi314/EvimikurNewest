using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class DealerStocks:BaseEntity
    {
        public int? DealerId { get; set; }
        public int? ProductId { get; set; }
        public int? Amount { get; set; }
        public int? MinimumAmount { get; set; }
        public int? SupplierId { get; set; }
        public decimal? Cost { get; set; }
        public decimal? SalesPrice { get; set; }

        public Supplier? Supplier { get; set; }
        public Dealer? Dealer { get; set; }
        public Product? Product { get; set; }

    }
}

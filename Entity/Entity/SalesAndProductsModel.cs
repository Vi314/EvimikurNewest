using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class SalesAndProductsModel :BaseEntity
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public SaleModel Sale { get; set; }
        public ProductModel Product { get; set; }
    }
}

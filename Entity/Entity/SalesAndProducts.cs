using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class SalesAndProducts
    {
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}

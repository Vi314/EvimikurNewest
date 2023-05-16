using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class SalesAndDealers
    {
        public int SaleId { get; set; }
        public int DealerId { get; set; }
        public Sale Sale { get; set; }
        public Dealer Dealer { get; set; }
    }
}

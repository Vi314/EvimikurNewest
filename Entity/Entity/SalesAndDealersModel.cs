using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class SalesAndDealersModel : BaseEntity
	{
        public int SaleId { get; set; }
        public int DealerId { get; set; }
        public SaleModel Sale { get; set; }
        public DealerModel Dealer { get; set; }
    }
}

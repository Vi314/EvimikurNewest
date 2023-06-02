using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class ProductPriceAndDealersModel:BaseEntity
	{
        public int ProductPriceId { get; set; }
        public int DealerId { get; set; }
		public ProductPriceModel ProductPrice { get; set; }
		public DealerModel Dealer { get; set; }
    }
}

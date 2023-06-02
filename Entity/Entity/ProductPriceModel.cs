using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class ProductPriceModel:BaseEntity
	{
        public int ProductId { get; set; }
        public decimal ProductionPrice { get; set; }
		public decimal TaxPrice { get; set; }
		public decimal SellingPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public DateTime ValidUntil { get; set; }
		public ProductModel Product { get; set; }
		public List<DealerModel> Dealers { get; set; }
	}
}

using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class ProductPrice:BaseEntity
	{
        public int ProductId { get; set; }
        public decimal ProductionPrice { get; set; }
		public decimal TaxPrice { get; set; }
		public decimal SellingPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public DateTime ValidUntil { get; set; }
		public Product Product { get; set; }
		public List<Dealer> Dealers { get; set; }
	}
}

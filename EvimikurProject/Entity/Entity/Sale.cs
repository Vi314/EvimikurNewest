using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class Sale:BaseEntity
	{
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		public List<Dealer>? Dealer { get; set; }
		public List<Product>? Product { get; set; }
	}
}

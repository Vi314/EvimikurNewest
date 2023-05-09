using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Non_Db_Objcets
{
	public class StockTransferObject
	{
		public int Quantity { get; set; }
		public int ToDealerId { get; set; }
		public int FromDealerId { get; set; }
		public int ProductId { get; set; }
	}
}

using Entity.Base;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class SupplierContract:BaseEntity
	{
		public int? SupplierId { get; set; }
        public DateTime? ContractSignDate { get; set; }
		public DateTime? ContractEndDate { get; set; }
		public DateTime? PaymentDate { get; set; }
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShippingCost { get; set; }
        public int? Amount { get; set; }
        public ContractState? ContractState { get; set; } = Enum.ContractState.ContractCreated;


        public Product? Product { get; set; }
		public Supplier? Supplier { get; set; }
	}
}

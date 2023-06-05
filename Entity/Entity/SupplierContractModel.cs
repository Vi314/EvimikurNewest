using Entity.Base;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class SupplierContractModel:BaseEntity
	{
        [Required]
        public int? SupplierId { get; set; }
        [Required]
        public DateTime ContractSignDate { get; set; }
        [Required]
        public DateTime ContractEndDate { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public decimal? Price { get; set; }
        public decimal? ShippingCost { get; set; }
        public int? Amount { get; set; }
        public ContractState? ContractState { get; set; } = Enum.ContractState.ContractCreated;


        public ProductModel? Product { get; set; }
		public SupplierModel? Supplier { get; set; }
	}
}

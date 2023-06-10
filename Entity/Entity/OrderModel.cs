using Entity.Base;
using Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class OrderModel : BaseEntity
    {
        [Required]
        public int DealerId { get; set; }

        public int EmployeeId { get; set; }
        public int? SupplierId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderType OrderType { get; set; }

        public SupplierModel? Supplier { get; set; }
        public EmployeeModel? Employee { get; set; }
        public DealerModel? Dealer { get; set; }
    }
}
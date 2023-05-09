using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Order:BaseEntity
    {
        [Required]
        public int DealerId { get; set; }
        public int EmployeeId { get; set; }
        public int? SupplierId { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        public Supplier? Supplier { get; set; }
        public Employee Employee { get; set; }
        public Dealer Dealer { get; set; }
    }
}

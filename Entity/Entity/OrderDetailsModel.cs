using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class OrderDetailsModel:BaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal Price { get; set; }

        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
    }
}

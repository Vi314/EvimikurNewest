﻿using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class DealerModel: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(2000)]
        public string? FullAdress { get; set; }

		public List<ProductPriceModel> ProductPrices { get; set; }
		public List<SaleModel> Sales { get; set; }
    }
}
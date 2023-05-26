﻿using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class ProductPriceAndDealers:BaseEntity
	{
        public int ProductPriceId { get; set; }
        public int DealerId { get; set; }
		public ProductPrice ProductPrice { get; set; }
		public Dealer Dealer { get; set; }
    }
}
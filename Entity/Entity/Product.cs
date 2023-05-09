using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Product:BaseEntity
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public float? LooksGrade { get; set; }
        public float? UsabilityGrade { get; set; }
        public float? FunctionalityGrade { get; set; }
        public float? InnovativeGrade { get; set; }
        public float? PriceAdvantageGrade { get; set; }
        public float? PotentialSalesGrade { get; set; }
        
		public Category? Category { get; set; }
        public List<Sale>? Sales { get; set; }
    }
}

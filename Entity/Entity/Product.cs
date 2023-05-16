using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Product:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string? ProductName { get; set; }
        [Required]
        [MaxLength(2000)]
        public string? Description { get; set; }
        public int? CategoryId { get; set; }

        [Range(0, 10)]
        public float? LooksGrade { get; set; }
        [Range(0, 10)]
        public float? UsabilityGrade { get; set; }
        [Range(0, 10)]
        public float? FunctionalityGrade { get; set; }
        [Range(0, 10)]
        public float? InnovativeGrade { get; set; }
        [Range(0, 10)]
        public float? PriceAdvantageGrade { get; set; }

        [Range(0, 10)]
        public float? PotentialSalesGrade { get; set; }

        public List<Sale> Sales { get; set; }
        public Category? Category { get; set; }
    }
}

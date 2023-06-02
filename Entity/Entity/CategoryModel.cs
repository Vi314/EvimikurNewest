using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class CategoryModel:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } 
        [DefaultValue("No Description")]
        [MaxLength(2000)]
        public string? Description { get; set; }
    }
}

using Entity.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class CategoryModel : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DefaultValue("No Description")]
        [MaxLength(2000)]
        public string? Description { get; set; }
    }
}
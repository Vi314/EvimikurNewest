using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class ProductDTO : BaseDto
    {
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(255, ErrorMessage = ErrorMessages.toolong255)]
        public string? Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(2000, ErrorMessage = ErrorMessages.toolong2000)]
        public string? Description { get; set; }

        [DefaultValue("Kategori Yok")]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? Category { get; set; }

        public int? CategoryId { get; set; }

        [Range(0, 10, ErrorMessage = "Değer 0 ile 10 arasında olmalıdır!")]
        public float? LooksGrade { get; set; }

        [Range(0, 10, ErrorMessage = "Değer 0 ile 10 arasında olmalıdır!")]
        public float? UsabilityGrade { get; set; }

        [Range(0, 10, ErrorMessage = "Değer 0 ile 10 arasında olmalıdır!")]
        public float? FunctionalityGrade { get; set; }

        [Range(0, 10, ErrorMessage = "Değer 0 ile 10 arasında olmalıdır!")]
        public float? InnovativeGrade { get; set; }

        [Range(0, 10, ErrorMessage = "Değer 0 ile 10 arasında olmalıdır!")]
        public float? PriceAdvantageGrade { get; set; }

        public float? PotentialSalesGrade { get; set; }
    }
}
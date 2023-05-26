using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entity.Entity;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class EmployeeDTO:BaseDTO
    {
        
        [Required(ErrorMessage = ErrorMessages.requiredField )]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? Department { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? EducationLevel { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(2000, ErrorMessage = ErrorMessages.toolong2000)]
        public string? FullAddress { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        [MaxLength(100, ErrorMessage = ErrorMessages.toolong100)]
        public string? Title { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public string? Dealer { get; set; }
        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int? DealerId { get; set; }

        public DateTime? HiredDate { get; set; }

    }
}

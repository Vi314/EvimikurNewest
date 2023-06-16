using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels
{
    public class EmployeeVacationDto : BaseDto
    {
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime VacationStart { get; set; } = DateTime.Now;

        [Required(ErrorMessage = ErrorMessages.requiredField)]
        public DateTime VacationEnd { get; set; } = DateTime.Now.AddDays(1);

        public int? VacationDuration { get; set; }
        public bool IsApproved { get; set; }
    }
}
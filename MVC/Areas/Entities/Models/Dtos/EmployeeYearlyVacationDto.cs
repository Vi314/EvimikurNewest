using System.ComponentModel.DataAnnotations;
using MVC.Areas.Entities.Models.BaseModels;

namespace MVC.Areas.Entities.Models.ViewModels;

public class EmployeeYearlyVacationDto : BaseDto
{
    [Required]
    public required string EmployeeName { get; set; }

    public int EmployeeId { get; set; }

    [Required]
    public int? Year { get; set; }

    public int? YearlyVacationDays { get; set; }
    public int? VacationDaysUsed { get; set; }
}
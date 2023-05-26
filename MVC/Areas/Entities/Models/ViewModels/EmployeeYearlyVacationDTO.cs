using System.ComponentModel.DataAnnotations;

namespace MVC.Areas.Entities.Models.ViewModels;
public class EmployeeYearlyVacationDTO:BaseDTO
{
    [Required]
    public string EmployeeName { get; set; }
    public int EmployeeId { get; set; }

    [Required]
	public int? Year { get; set; }
    public int? YearlyVacationDays { get; set; }
    public int? VacationDaysUsed { get; set; }
}
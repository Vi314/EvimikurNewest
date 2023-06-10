using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity;

public class EmployeeMonthlyWagesModel : BaseEntity
{
    public DateTime Month { get; set; }

    [Required]
    public decimal Wage { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    public EmployeeModel Employee { get; set; } = new();
}
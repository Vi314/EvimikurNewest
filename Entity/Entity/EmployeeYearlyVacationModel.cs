using Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entity
{
    public class EmployeeYearlyVacationModel : BaseEntity
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int? Year { get; set; }

        public int? YearlyVacationDays { get; set; }
        public int? VacationDaysUsed { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
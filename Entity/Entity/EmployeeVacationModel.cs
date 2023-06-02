using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity;
public class EmployeeVacationModel:BaseEntity
{
	[Required]
	public int EmployeeId { get; set; }
	[Required]
        public DateTime VacationStart { get; set; }
	[Required]
        public DateTime VacationEnd { get;set; }
	public int? VacationDuration { get; set; }
	public bool IsApproved { get; set; }

	public EmployeeModel Employee { get; set; }
}

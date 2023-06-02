using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity;
public class EmployeeMonthlyWagesModel : BaseEntity
{
	public DateTime Month { get; set; }
	[Required]
	public decimal Wage { get; set; }
	[Required]
	public int EmployeeId { get; set; }
	public EmployeeModel Employee { get; set; }
}

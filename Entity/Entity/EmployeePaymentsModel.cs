using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity;
public class EmployeePaymentsModel : BaseEntity
{
	[MaxLength(255)]
	public string Description { get; set; }
	public DateTime PaymentDate { get; set; }
	[Required]
	public decimal Payment { get; set; }
	[Required]
	public int EmployeeId { get; set; }
	public EmployeeModel Employee { get; set; }
}

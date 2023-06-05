using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Base;

namespace Entity.Entity
{
	public class EmployeeInsuranceActionModel:BaseEntity
	{
		public DateTime Date { get; set; }
		[Required]
		public int? EmployeeId { get; set; }
		[Required]
		[MaxLength(255)]
		public string? Hospital { get; set; }
		[MaxLength(2000)]
		public string? Description { get; set; }

		public EmployeeModel? Employee { get; set; }
	}
}

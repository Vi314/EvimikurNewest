using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Base;

namespace Entity.Entity
{
	public class EmployeeInsuranceAction:BaseEntity
	{
		public DateTime? Date { get; set; }
		public int? EmployeeId { get; set; }
		public string? Hospital { get; set; }
		public string? Description { get; set; }

		public Employee? Employee { get; set; }
	}
}

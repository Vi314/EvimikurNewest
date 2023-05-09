using Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class EmployeeEntryExit:BaseEntity
	{
		[Required]
		public int? EmployeeId { get; set; }
		public DateTime EntryTime { get; set; }
		public DateTime ExitTime { get; set; }
		
		public Employee Employee { get; set; }
	}
}

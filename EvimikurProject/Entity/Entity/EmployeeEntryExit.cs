using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class EmployeeEntryExit:BaseEntity
	{
		public int? EmployeeId { get; set; }
		public DateTime EntryTime { get; set; }
		public DateTime ExitTime { get; set; }
		public Employee Employee { get; set; }
	}
}

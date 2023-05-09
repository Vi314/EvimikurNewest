﻿using Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
	public class EmployeeVacation:BaseEntity
	{
		public int? EmployeeId { get; set; }
		public DateTime? VacationStart { get; set; }
		public DateTime? VacationEnd { get;set; }
		public int? VacationDuration { get; set; }
		public bool? IsApproved { get; set; }

		public Employee? Employee { get; set; }
	}
}

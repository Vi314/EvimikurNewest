﻿using Entity.Entity;
using Entity.Non_Db_Objcets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeEntryExitService
	{
		string CreateOne(EmployeeEntryExit employeeEntryExit);
		string UpdateOne(EmployeeEntryExit employeeEntryExit);
		string DeleteEmployeeEntryExit(int id);
		IEnumerable<EmployeeEntryExit> GetEmployeeEntryExit();
		EmployeeEntryExit GetById(int id);
	}
}

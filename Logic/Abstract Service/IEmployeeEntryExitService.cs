using Entity.Entity;
using Entity.Non_Db_Objcets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeEntryExitService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExit> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExit> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(EmployeeEntryExit employeeEntryExit);
		HttpStatusCode UpdateOne(EmployeeEntryExit employeeEntryExit);
		HttpStatusCode DeleteEmployeeEntryExit(int id);
		IEnumerable<EmployeeEntryExit> GetEmployeeEntryExit();
		EmployeeEntryExit GetById(int id);
	}
}

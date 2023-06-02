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
		HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExitModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExitModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(EmployeeEntryExitModel employeeEntryExit);
		HttpStatusCode UpdateOne(EmployeeEntryExitModel employeeEntryExit);
		HttpStatusCode DeleteEmployeeEntryExit(int id);
		IEnumerable<EmployeeEntryExitModel> GetEmployeeEntryExit();
		EmployeeEntryExitModel GetById(int id);
	}
}

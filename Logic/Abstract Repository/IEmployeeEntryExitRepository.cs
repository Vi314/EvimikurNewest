using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeEntryExitRepository
	{
		HttpStatusCode Create(EmployeeEntryExitModel employeeEntryExit);
		HttpStatusCode Update(EmployeeEntryExitModel employeeEntryExit);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExitModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExitModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeEntryExitModel GetById(int id);
		IEnumerable<EmployeeEntryExitModel> GetAll();
		int ExecuteRawSql(string command);
	}
}

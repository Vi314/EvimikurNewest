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
		HttpStatusCode Create(EmployeeEntryExit employeeEntryExit);
		HttpStatusCode Update(EmployeeEntryExit employeeEntryExit);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExit> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExit> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeEntryExit GetById(int id);
		IEnumerable<EmployeeEntryExit> GetAll();
		int ExecuteRawSql(string command);
	}
}

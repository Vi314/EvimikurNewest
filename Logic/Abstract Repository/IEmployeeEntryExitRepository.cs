using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeEntryExitRepository
	{
		string Create(EmployeeEntryExit employeeEntryExit);
		string Update(EmployeeEntryExit employeeEntryExit);
		string Delete(int id);
		EmployeeEntryExit GetById(int id);
		IEnumerable<EmployeeEntryExit> GetAll();
		int ExecuteRawSql(string command);
	}
}

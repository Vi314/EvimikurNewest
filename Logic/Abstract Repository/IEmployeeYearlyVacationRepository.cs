using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeYearlyVacationRepository
	{
		HttpStatusCode Create(EmployeeYearlyVacation employeeYearlyVacation);
		HttpStatusCode Update(EmployeeYearlyVacation employeeYearlyVacation);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeYearlyVacation> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeYearlyVacation> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeYearlyVacation GetById(int id);
		IEnumerable<EmployeeYearlyVacation> GetAll();
		int ExecuteRawSql(string command);
	}
}

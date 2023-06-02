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
		HttpStatusCode Create(EmployeeYearlyVacationModel employeeYearlyVacation);
		HttpStatusCode Update(EmployeeYearlyVacationModel employeeYearlyVacation);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeYearlyVacationModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeYearlyVacationModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		void ResetYearlyVacations();
        EmployeeYearlyVacationModel GetByYearAndEmployee(int year, int employeeId);
        EmployeeYearlyVacationModel GetById(int id);
		IEnumerable<EmployeeYearlyVacationModel> GetAll();
		int ExecuteRawSql(string command);
	}
}

using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeYearlyVacationRepository
	{
		string Create(EmployeeYearlyVacation employeeYearlyVacation);
		string Update(EmployeeYearlyVacation employeeYearlyVacation);
		string Delete(int id);
		EmployeeYearlyVacation GetById(int id);
		IEnumerable<EmployeeYearlyVacation> GetAll();
		int ExecuteRawSql(string command);
	}
}

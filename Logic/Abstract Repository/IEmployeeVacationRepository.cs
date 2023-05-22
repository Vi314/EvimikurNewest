using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeVacationRepository
	{
		string Create(EmployeeVacation employeeVacation);
		string Update(EmployeeVacation employeeVacation);
		string Delete(int id);
		EmployeeVacation GetById(int id);
		IEnumerable<EmployeeVacation> GetAll();
		int ExecuteRawSql(string command);
	}
}

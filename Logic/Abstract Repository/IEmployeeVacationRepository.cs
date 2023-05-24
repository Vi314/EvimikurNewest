using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeVacationRepository
	{
		HttpStatusCode Create(EmployeeVacation employeeVacation);
		HttpStatusCode Update(EmployeeVacation employeeVacation);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeVacation> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeVacation> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeVacation GetById(int id);
		IEnumerable<EmployeeVacation> GetAll();
		int ExecuteRawSql(string command);
	}
}

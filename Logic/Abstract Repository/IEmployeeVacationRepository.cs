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
		HttpStatusCode Create(EmployeeVacationModel employeeVacation);
		HttpStatusCode Update(EmployeeVacationModel employeeVacation);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeVacationModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeVacationModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeVacationModel GetById(int id);
		IEnumerable<EmployeeVacationModel> GetAll();
		int ExecuteRawSql(string command);
	}
}

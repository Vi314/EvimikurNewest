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
	public interface IEmployeeVacationService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeeVacationModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeVacationModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(EmployeeVacationModel employeeVacation);
		HttpStatusCode UpdateOne(EmployeeVacationModel employeeVacation);
		HttpStatusCode DeleteEmployeeVacation(int id);
		IEnumerable<EmployeeVacationModel> GetEmployeeVacation();
		EmployeeVacationModel GetById(int id);
	}
}

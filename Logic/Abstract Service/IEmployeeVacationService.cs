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
		HttpStatusCode CreateRange(IEnumerable<EmployeeVacation> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeVacation> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(EmployeeVacation employeeVacation);
		HttpStatusCode UpdateOne(EmployeeVacation employeeVacation);
		HttpStatusCode DeleteEmployeeVacation(int id);
		IEnumerable<EmployeeVacation> GetEmployeeVacation();
		EmployeeVacation GetById(int id);
	}
}

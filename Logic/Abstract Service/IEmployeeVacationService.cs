using Entity.Entity;
using Entity.Non_Db_Objcets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeVacationService
	{
		string CreateEmployeeVacation(EmployeeVacation employeeVacation);
		string UpdateEmployeeVacation(EmployeeVacation employeeVacation);
		string DeleteEmployeeVacation(int id);
		IEnumerable<EmployeeVacation> GetEmployeeVacation();
		EmployeeVacation GetById(int id);
	}
}

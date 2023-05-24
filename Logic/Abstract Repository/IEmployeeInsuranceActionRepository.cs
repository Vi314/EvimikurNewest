using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeInsuranceActionRepository
	{
		HttpStatusCode Create(EmployeeInsuranceAction employeeInsuranceAction);
		HttpStatusCode Update(EmployeeInsuranceAction employeeInsuranceAction);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceAction> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceAction> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeInsuranceAction GetById(int id);
		IEnumerable<EmployeeInsuranceAction> GetAll();
		int ExecuteRawSql(string command);
	}
}

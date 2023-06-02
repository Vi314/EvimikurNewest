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
		HttpStatusCode Create(EmployeeInsuranceActionModel employeeInsuranceAction);
		HttpStatusCode Update(EmployeeInsuranceActionModel employeeInsuranceAction);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceActionModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceActionModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeInsuranceActionModel GetById(int id);
		IEnumerable<EmployeeInsuranceActionModel> GetAll();
		int ExecuteRawSql(string command);
	}
}

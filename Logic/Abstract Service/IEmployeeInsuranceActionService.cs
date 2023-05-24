using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeInsuranceActionService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceAction> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceAction> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(EmployeeInsuranceAction insuranceAction);
		HttpStatusCode UpdateOne(EmployeeInsuranceAction insuranceAction);
		HttpStatusCode DeleteEmployeeInsuranceAction(int id);
		IEnumerable<EmployeeInsuranceAction> GetEmployeeInsuranceActions();
		EmployeeInsuranceAction GetById(int id);
	}
}

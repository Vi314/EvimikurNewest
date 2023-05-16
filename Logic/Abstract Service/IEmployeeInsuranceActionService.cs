using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeInsuranceActionService
	{
		string CreateOne(EmployeeInsuranceAction insuranceAction);
		string UpdateOne(EmployeeInsuranceAction insuranceAction);
		string DeleteEmployeeInsuranceAction(int id);
		IEnumerable<EmployeeInsuranceAction> GetEmployeeInsuranceActions();
		EmployeeInsuranceAction GetById(int id);
	}
}

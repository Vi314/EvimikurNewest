using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeInsuranceActionRepository
	{
		string Create(EmployeeInsuranceAction employeeInsuranceAction);
		string Update(EmployeeInsuranceAction employeeInsuranceAction);
		string Delete(int id);
		EmployeeInsuranceAction GetById(int id);
		IEnumerable<EmployeeInsuranceAction> GetAll();
		int ExecuteRawSql(string command);
	}
}

using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeMonthlyWagesRepository
	{
		HttpStatusCode Create(EmployeeMonthlyWages Thing);
		HttpStatusCode Update(EmployeeMonthlyWages Thing);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeMonthlyWages> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeMonthlyWages> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeMonthlyWages GetById(int id);
		IEnumerable<EmployeeMonthlyWages> GetAll();
		int ExecuteRawSql(string command);
	}
}

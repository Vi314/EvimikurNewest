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
		HttpStatusCode Create(EmployeeMonthlyWagesModel Thing);
		HttpStatusCode Update(EmployeeMonthlyWagesModel Thing);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeeMonthlyWagesModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeMonthlyWagesModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeeMonthlyWagesModel GetById(int id);
		IEnumerable<EmployeeMonthlyWagesModel> GetAll();
		int ExecuteRawSql(string command);
	}
}

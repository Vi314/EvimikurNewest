using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeePaymentsRepository
	{
		HttpStatusCode Create(EmployeePaymentsModel Thing);
		HttpStatusCode Update(EmployeePaymentsModel Thing);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeePaymentsModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeePaymentsModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeePaymentsModel GetById(int id);
		IEnumerable<EmployeePaymentsModel> GetAll();
		int ExecuteRawSql(string command);
	}
}

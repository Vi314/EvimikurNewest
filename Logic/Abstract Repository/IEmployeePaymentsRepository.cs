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
		HttpStatusCode Create(EmployeePayments Thing);
		HttpStatusCode Update(EmployeePayments Thing);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<EmployeePayments> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeePayments> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		EmployeePayments GetById(int id);
		IEnumerable<EmployeePayments> GetAll();
		int ExecuteRawSql(string command);
	}
}

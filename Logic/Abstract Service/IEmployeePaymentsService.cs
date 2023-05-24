using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeePaymentsService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeePayments> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeePayments> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(EmployeePayments dealer);
		HttpStatusCode UpdateOne(EmployeePayments dealer);
		HttpStatusCode DeleteOne(int id);
		IEnumerable<EmployeePayments> GetAll();
		EmployeePayments GetById(int id);

	}
}

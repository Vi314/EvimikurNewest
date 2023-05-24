using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeMonthlyWagesService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeeMonthlyWages> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeMonthlyWages> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(EmployeeMonthlyWages thing);
		HttpStatusCode UpdateOne(EmployeeMonthlyWages thing);
		HttpStatusCode DeleteOne(int id);
		IEnumerable<EmployeeMonthlyWages> GetAll();
		EmployeeMonthlyWages GetById(int id);
	}
}

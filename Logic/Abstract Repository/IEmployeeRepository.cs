using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeRepository
	{
		HttpStatusCode Create(Employee employee);
		HttpStatusCode Update(Employee employee);
		HttpStatusCode Delete(int id);
		HttpStatusCode CreateRange(IEnumerable<Employee> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Employee> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		Employee GetById(int id);
		IEnumerable<Employee> GetAll();
		int ExecuteRawSql(string command);
	}
}

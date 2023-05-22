using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Repository
{
	public interface IEmployeeRepository
	{
		string Create(Employee employee);
		string Update(Employee employee);
		string Delete(int id);
		Employee GetById(int id);
		IEnumerable<Employee> GetAll();
		int ExecuteRawSql(string command);
	}
}

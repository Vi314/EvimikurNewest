using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeService
    {
		HttpStatusCode CreateRange(IEnumerable<Employee> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Employee> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(Employee employee);
        HttpStatusCode UpdateOne(Employee employee);
        HttpStatusCode DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee GetById(int id);

}
}
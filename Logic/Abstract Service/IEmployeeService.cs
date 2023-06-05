using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeService
    {
        HttpStatusCode CreateRange(IEnumerable<EmployeeModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(EmployeeModel employee);

        HttpStatusCode UpdateOne(EmployeeModel employee);

        HttpStatusCode DeleteEmployee(int id);

        IEnumerable<EmployeeModel> GetEmployees();

        EmployeeModel GetById(int id);
    }
}
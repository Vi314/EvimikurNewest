using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IEmployeeRepository
    {
        HttpStatusCode Create(EmployeeModel employee);

        HttpStatusCode Update(EmployeeModel employee);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<EmployeeModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        EmployeeModel GetById(int id);

        IEnumerable<EmployeeModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
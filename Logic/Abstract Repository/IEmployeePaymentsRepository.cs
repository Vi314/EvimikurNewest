using Entity.Entity;
using System.Net;

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
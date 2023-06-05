using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeePaymentsService
    {
        HttpStatusCode CreateRange(IEnumerable<EmployeePaymentsModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeePaymentsModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(EmployeePaymentsModel dealer);

        HttpStatusCode UpdateOne(EmployeePaymentsModel dealer);

        HttpStatusCode DeleteOne(int id);

        IEnumerable<EmployeePaymentsModel> GetAll();

        EmployeePaymentsModel GetById(int id);
    }
}
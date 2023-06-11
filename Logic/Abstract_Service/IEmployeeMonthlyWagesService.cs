using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeMonthlyWagesService
    {
        HttpStatusCode CreateRange(IEnumerable<EmployeeMonthlyWagesModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeMonthlyWagesModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(EmployeeMonthlyWagesModel thing);

        HttpStatusCode UpdateOne(EmployeeMonthlyWagesModel thing);

        HttpStatusCode DeleteOne(int id);

        IEnumerable<EmployeeMonthlyWagesModel> GetAll();

        EmployeeMonthlyWagesModel GetById(int id);
    }
}
using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IEmployeeMonthlyWagesRepository
    {
        HttpStatusCode Create(EmployeeMonthlyWagesModel Thing);

        HttpStatusCode Update(EmployeeMonthlyWagesModel Thing);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<EmployeeMonthlyWagesModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeMonthlyWagesModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        EmployeeMonthlyWagesModel GetById(int id);

        IEnumerable<EmployeeMonthlyWagesModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
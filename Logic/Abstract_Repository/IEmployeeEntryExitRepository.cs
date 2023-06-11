using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IEmployeeEntryExitRepository
    {
        HttpStatusCode Create(EmployeeEntryExitModel employeeEntryExit);

        HttpStatusCode Update(EmployeeEntryExitModel employeeEntryExit);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExitModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExitModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        EmployeeEntryExitModel GetById(int id);

        IEnumerable<EmployeeEntryExitModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
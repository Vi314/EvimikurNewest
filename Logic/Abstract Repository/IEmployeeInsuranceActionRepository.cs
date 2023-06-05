using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IEmployeeInsuranceActionRepository
    {
        HttpStatusCode Create(EmployeeInsuranceActionModel employeeInsuranceAction);

        HttpStatusCode Update(EmployeeInsuranceActionModel employeeInsuranceAction);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceActionModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceActionModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        EmployeeInsuranceActionModel GetById(int id);

        IEnumerable<EmployeeInsuranceActionModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
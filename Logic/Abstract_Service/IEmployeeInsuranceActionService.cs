using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeInsuranceActionService
    {
        HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceActionModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceActionModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(EmployeeInsuranceActionModel insuranceAction);

        HttpStatusCode UpdateOne(EmployeeInsuranceActionModel insuranceAction);

        HttpStatusCode DeleteEmployeeInsuranceAction(int id);

        IEnumerable<EmployeeInsuranceActionModel> GetEmployeeInsuranceActions();

        EmployeeInsuranceActionModel GetById(int id);
    }
}
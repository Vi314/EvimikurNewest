using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeVacationService
    {
        HttpStatusCode CreateRange(IEnumerable<EmployeeVacationModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeVacationModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(EmployeeVacationModel employeeVacation);

        HttpStatusCode UpdateOne(EmployeeVacationModel employeeVacation);

        HttpStatusCode DeleteEmployeeVacation(int id);

        IEnumerable<EmployeeVacationModel> GetEmployeeVacation();

        EmployeeVacationModel GetById(int id);
    }
}
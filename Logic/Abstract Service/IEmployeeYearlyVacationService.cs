using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeYearlyVacationService
    {
        HttpStatusCode CreateRange(IEnumerable<EmployeeYearlyVacationModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<EmployeeYearlyVacationModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(EmployeeYearlyVacationModel employeeYearlyVacation);

        HttpStatusCode UpdateOne(EmployeeYearlyVacationModel employeeYearlyVacation);

        HttpStatusCode DeleteOne(int id);

        IEnumerable<EmployeeYearlyVacationModel> GetAll();

        EmployeeYearlyVacationModel GetById(int id);

        HttpStatusCode CalculateAll();

        int VacationsFromWorkYears(int? years);

        void ResetYearlyVacations(List<EmployeeYearlyVacationModel> model);
    }
}
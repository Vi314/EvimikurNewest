using Entity.Entity;
using Logic.Abstract_Generic;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IEmployeeYearlyVacationService:IBaseService<EmployeeYearlyVacationModel>
    {

        HttpStatusCode CalculateAll();

        int VacationsFromWorkYears(int? years);

        void ResetYearlyVacations(List<EmployeeYearlyVacationModel> model);
    }
}
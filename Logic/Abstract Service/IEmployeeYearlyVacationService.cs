using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
    public interface IEmployeeYearlyVacationService
    {
        string CreateOne(EmployeeYearlyVacation employeeYearlyVacation);
        string UpdateOne(EmployeeYearlyVacation employeeYearlyVacation);
        string DeleteOne(int id);
        IEnumerable<EmployeeYearlyVacation> GetAll();
        EmployeeYearlyVacation GetById(int id);
        void UpdateUsedVacations();
        void CalculateAll();
    }
}

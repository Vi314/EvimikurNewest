using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Abstract_Service
{
	public interface IEmployeeYearlyVacationService
	{
		HttpStatusCode CreateRange(IEnumerable<EmployeeYearlyVacation> Thing);
		HttpStatusCode UpdateRange(IEnumerable<EmployeeYearlyVacation> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(EmployeeYearlyVacation employeeYearlyVacation);
		HttpStatusCode UpdateOne(EmployeeYearlyVacation employeeYearlyVacation);
		HttpStatusCode DeleteOne(int id);

		IEnumerable<EmployeeYearlyVacation> GetAll();
		EmployeeYearlyVacation GetById(int id);
		
		void CalculateAll();
		int VacationsFromWorkYears(int years);
		void ResetYearlyVacations();

	}
}

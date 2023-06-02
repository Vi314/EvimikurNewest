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

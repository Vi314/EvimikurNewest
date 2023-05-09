using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeVacationMapper: IEmployeeVacationMapper
	{
		public EmployeeVacationDTO FromEmployeeVacation(EmployeeVacation vacation, List<Employee> employees)
		{
			var dto = new EmployeeVacationDTO
			{
				Id	= vacation.Id,
				IsApproved = vacation.IsApproved,
				VacationDuration = vacation.VacationDuration,
				VacationStart = vacation.VacationStart,
				VacationEnd = vacation.VacationEnd
			};
			dto.EmployeeName = employees.Where(x => x.Id == vacation.EmployeeId).Select(x => x.FirstName).FirstOrDefault();
			return dto;
		}

		public EmployeeVacation ToEmployeeVacation(EmployeeVacationDTO vacationDto, List<Employee> employees)
		{
			var empVacation = new EmployeeVacation
			{
				Id = vacationDto.Id,
				IsApproved = vacationDto.IsApproved,
				VacationDuration = vacationDto.VacationDuration,
				VacationStart = vacationDto.VacationStart,
				VacationEnd = vacationDto.VacationEnd
			};
			empVacation.EmployeeId = employees.Where(x=>x.FirstName == vacationDto.EmployeeName).Select(x=>x.Id).FirstOrDefault();
			return empVacation;
		}
	}
}

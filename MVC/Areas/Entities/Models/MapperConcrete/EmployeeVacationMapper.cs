using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeVacationMapper: IEmployeeVacationMapper
	{
		public EmployeeVacationDTO FromEntity(EmployeeVacation vacation)
		{
			var dto = new EmployeeVacationDTO
			{
				Id = vacation.Id,
				IsApproved = vacation.IsApproved,
				VacationDuration = vacation.VacationDuration,
				VacationStart = vacation.VacationStart,
				VacationEnd = vacation.VacationEnd,
				EmployeeName = vacation.Employee.FirstName,
				EmployeeId = vacation.EmployeeId,
			};
			return dto;
		}

		public EmployeeVacation FromDto(EmployeeVacationDTO vacationDto)
		{
			var empVacation = new EmployeeVacation
			{
				Id = vacationDto.Id,
				IsApproved = vacationDto.IsApproved,
				VacationDuration = vacationDto.VacationDuration,
				VacationStart = vacationDto.VacationStart,
				VacationEnd = vacationDto.VacationEnd,
				EmployeeId = vacationDto.EmployeeId
			};
			return empVacation;
		}
	}
}

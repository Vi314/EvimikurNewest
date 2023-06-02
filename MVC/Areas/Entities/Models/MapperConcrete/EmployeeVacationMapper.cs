using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeVacationMapper: IEmployeeVacationMapper
	{
		public EmployeeVacationDTO FromEntity(EmployeeVacationModel vacation)
		{
			var dto = new EmployeeVacationDTO
			{
				Id = vacation.Id,
				IsApproved = vacation.IsApproved,
				VacationDuration = vacation.VacationDuration,
				VacationStart = vacation.VacationStart.ToString("MM/dd/yyyy"),
				VacationEnd = vacation.VacationEnd.ToString("MM/dd/yyyy"),
				EmployeeName = vacation.Employee.FirstName,
				EmployeeId = vacation.EmployeeId,
			};
			return dto;
		}

		public EmployeeVacationModel FromDto(EmployeeVacationDTO vacationDto)
		{
			var empVacation = new EmployeeVacationModel
			{
				Id = vacationDto.Id,
				IsApproved = vacationDto.IsApproved,
				VacationDuration = vacationDto.VacationDuration,
				VacationStart = Convert.ToDateTime(vacationDto.VacationStart),
				VacationEnd = Convert.ToDateTime(vacationDto.VacationEnd),
				EmployeeId = vacationDto.EmployeeId
			};
			return empVacation;
		}
	}
}

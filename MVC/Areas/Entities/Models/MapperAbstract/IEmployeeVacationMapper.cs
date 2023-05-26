using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IEmployeeVacationMapper
	{
		public EmployeeVacation FromDto(EmployeeVacationDTO vacationDto);
		public EmployeeVacationDTO FromEntity(EmployeeVacation vacation);

	}
}

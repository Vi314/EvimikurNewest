using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IEmployeeVacationMapper
	{
		public EmployeeVacation ToEmployeeVacation(EmployeeVacationDTO vacationDto,List<Employee> employees);
		public EmployeeVacationDTO FromEmployeeVacation(EmployeeVacation vacation, List<Employee> employees);

	}
}

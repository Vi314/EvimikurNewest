using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IEmployeeEntryExitMapper
	{
		public EmployeeEntryExit ToEmployeeEntryExit(EmployeeEntryExitDTO entryExitDTO, List<Employee> employees);
		public EmployeeEntryExitDTO FromEmployeeEntryExit(EmployeeEntryExit entryExit, List<Employee> employees);
	}
}

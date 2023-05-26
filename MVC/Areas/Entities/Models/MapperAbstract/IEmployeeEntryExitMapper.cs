using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IEmployeeEntryExitMapper
	{
		public EmployeeEntryExit FromDto(EmployeeEntryExitDTO entryExitDTO);
		public EmployeeEntryExitDTO FromEntity(EmployeeEntryExit entryExit);
	}
}

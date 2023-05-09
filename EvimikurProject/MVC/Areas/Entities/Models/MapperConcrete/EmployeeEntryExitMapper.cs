using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeEntryExitMapper: IEmployeeEntryExitMapper
	{
		public EmployeeEntryExit ToEmployeeEntryExit(EmployeeEntryExitDTO entryExitDTO, List<Employee> employees)
		{
			var entryExit = new EmployeeEntryExit
			{
				Id = entryExitDTO.Id,
				EntryTime = entryExitDTO.Entry,
				ExitTime = entryExitDTO.Exit
			};
			entryExit.EmployeeId = employees.Where(x=>x.FirstName == entryExitDTO.EmployeeName).Select(x => x.Id).FirstOrDefault();
			return entryExit;
		}

		public EmployeeEntryExitDTO FromEmployeeEntryExit(EmployeeEntryExit entryExit, List<Employee> employees)
		{
			var entryExitDTO = new EmployeeEntryExitDTO
			{
				Id = entryExit.Id,
				Entry = entryExit.EntryTime,
				Exit = entryExit.ExitTime
			};
			entryExitDTO.EmployeeName = employees.Where(x=>x.Id == entryExit.Id).Select(x=>x.FirstName).FirstOrDefault();
			return entryExitDTO;
		}
	}
}

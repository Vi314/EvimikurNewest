﻿using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeEntryExitMapper: IEmployeeEntryExitMapper
	{
		public EmployeeEntryExitModel FromDto(EmployeeEntryExitDTO entryExitDTO)
		{
			var entryExit = new EmployeeEntryExitModel
			{
				Id = entryExitDTO.Id,
				EntryTime = entryExitDTO.Entry,
				ExitTime = entryExitDTO.Exit,
				EmployeeId = entryExitDTO.EmployeeId,
			};
			return entryExit;
		}

		public EmployeeEntryExitDTO FromEntity(EmployeeEntryExitModel entryExit)
		{
			var entryExitDTO = new EmployeeEntryExitDTO
			{
				Id = entryExit.Id,
				Entry = entryExit.EntryTime,
				Exit = entryExit.ExitTime,
				EmployeeName = entryExit.Employee.FirstName + " " + entryExit.Employee.LastName,
			};
			return entryExitDTO;
		}
	}
}

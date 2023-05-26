using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
	public class EmployeeEntryExitRepository : BaseRepository<EmployeeEntryExit>, IEmployeeEntryExitRepository
	{
		private readonly Context _context;

		public EmployeeEntryExitRepository(Context context) : base(context)
		{
			_context = context;
		}
        public override IEnumerable<EmployeeEntryExit> GetAll()
        {
			var entryExit = from ex in _context.EmployeeEntryExits
							join e in _context.Employees on ex.EmployeeId equals e.Id
							where ex.State != EntityState.Deleted
								&& e.State != EntityState.Deleted
							select new EmployeeEntryExit
							{
								CreatedDate = ex.CreatedDate,
								EmployeeId = ex.EmployeeId,
								Employee = e,
								EntryTime = ex.EntryTime,
								ExitTime = ex.ExitTime,
								Id = ex.Id,
								State = ex.State,
							};

            return entryExit;
        }
		public override EmployeeEntryExit GetById(int id)
		{
			var entryExit = (from ex in _context.EmployeeEntryExits
							join e in _context.Employees on ex.EmployeeId equals e.Id
							where e.Id == id
								&& ex.State != EntityState.Deleted
								&& e.State != EntityState.Deleted
							select new EmployeeEntryExit
							{
								CreatedDate = ex.CreatedDate,
								EmployeeId = ex.EmployeeId,
								Employee = e,
								EntryTime = ex.EntryTime,
								ExitTime = ex.ExitTime,
								Id = ex.Id,
								State = ex.State,
							}).FirstOrDefault();

			return entryExit;
		}
	}
}

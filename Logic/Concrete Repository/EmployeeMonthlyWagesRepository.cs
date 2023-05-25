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
	public class EmployeeMonthlyWagesRepository : BaseRepository<EmployeeMonthlyWages>, IEmployeeMonthlyWagesRepository
	{
		private readonly Context _context;

		public EmployeeMonthlyWagesRepository(Context context) : base(context)
		{
			var wages = from mw in _context.EmployeeMonthlyWages
					   join e in _context.Employees on mw.EmployeeId equals e.Id
					   where mw.State != EntityState.Deleted
						&& e.State != EntityState.Deleted
					   select new EmployeeMonthlyWages
					   {
						   CreatedDate = mw.CreatedDate,
						   Employee = e,
						   EmployeeId = mw.EmployeeId,
						   Id = mw.Id,
						   Month = mw.Month,
						   State = mw.State,
						   Wage = mw.Wage,
					   };
			return wages;
		}
	}
}

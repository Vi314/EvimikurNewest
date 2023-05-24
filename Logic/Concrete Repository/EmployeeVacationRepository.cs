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
	public class EmployeeVacationRepository : BaseRepository<EmployeeVacation>, IEmployeeVacationRepository
	{
		private readonly Context _context;

		public EmployeeVacationRepository(Context context) : base(context)
		{
			_context = context;
		}
		public override IEnumerable<EmployeeVacation> GetAll()
		{
			var vacations = from vacation in _context.EmployeeVacations
							join employee in _context.Employees on vacation.EmployeeId equals employee.Id
							where vacation.State != EntityState.Deleted
                            select new EmployeeVacation
							{
								Id = vacation.Id,
								IsApproved = vacation.IsApproved,
								CreatedDate	= vacation.CreatedDate,
								EmployeeId = employee.Id,
								State = vacation.State,
								VacationDuration = vacation.VacationDuration,
								VacationEnd = vacation.VacationEnd,
								VacationStart = vacation.VacationStart,
								Employee = employee,
							};

			return vacations;
		}
		public override EmployeeVacation GetById(int id)
		{
			var entity = from vacation in _context.EmployeeVacations
						   join employee in _context.Employees on vacation.EmployeeId equals employee.Id
						 where employee.Id == id 
							&& vacation.State != EntityState.Deleted
							&& employee.State != EntityState.Deleted
                         select new EmployeeVacation
						   {
							   Id = vacation.Id,
							   IsApproved = vacation.IsApproved,
							   CreatedDate = vacation.CreatedDate,
							   EmployeeId = employee.Id,
							   State = vacation.State,
							   VacationDuration = vacation.VacationDuration,
							   VacationEnd = vacation.VacationEnd,
							   VacationStart = vacation.VacationStart,
							   Employee = employee,
						   };

			return (EmployeeVacation)entity;
		}
	}
}

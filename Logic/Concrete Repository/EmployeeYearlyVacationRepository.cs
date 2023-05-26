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
	public class EmployeeYearlyVacationRepository : BaseRepository<EmployeeYearlyVacation>, IEmployeeYearlyVacationRepository
	{
		private readonly Context _context;

		public EmployeeYearlyVacationRepository(Context context) : base(context)
		{
			_context = context;
		}

        public override IEnumerable<EmployeeYearlyVacation> GetAll()
        {
			var yVacations = from yv in _context.EmployeeYearlyVacations
							 join e in _context.Employees on yv.EmployeeId equals e.Id
							 where yv.State != EntityState.Deleted
								&& e.State != EntityState.Deleted
							 select new EmployeeYearlyVacation
							 {
								State = yv.State,
								EmployeeId = yv.EmployeeId,
								Employee = yv.Employee,
								CreatedDate = yv.CreatedDate,
								Id = yv.Id,
								VacationDaysUsed = yv.VacationDaysUsed,
								Year = yv.Year,
								YearlyVacationDays = yv.YearlyVacationDays,
								 
							 };

            return yVacations;
        }
		public override EmployeeYearlyVacation GetById(int id)
		{
			var yVacation = (from yv in _context.EmployeeYearlyVacations
							 join e in _context.Employees on yv.EmployeeId equals e.Id
							 where yv.Id == id
								&& yv.State != EntityState.Deleted
								&& e.State != EntityState.Deleted
							 select new EmployeeYearlyVacation
							 {
								 State = yv.State,
								 EmployeeId = yv.EmployeeId,
								 Employee = yv.Employee,
								 CreatedDate = yv.CreatedDate,
								 Id = yv.Id,
								 VacationDaysUsed = yv.VacationDaysUsed,
								 Year = yv.Year,
								 YearlyVacationDays = yv.YearlyVacationDays,

							 }).FirstOrDefault();

			return yVacation;
		}
	}
}

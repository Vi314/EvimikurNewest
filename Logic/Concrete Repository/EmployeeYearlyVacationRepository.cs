using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class EmployeeYearlyVacationRepository : BaseRepository<EmployeeYearlyVacationModel>, IEmployeeYearlyVacationRepository
    {
        private readonly Context _context;

        public EmployeeYearlyVacationRepository(Context context) : base(context)
        {
            _context = context;
        }

        public void ResetYearlyVacations()
        {
            var yearlyVacations = GetAll().ToList();
            yearlyVacations.ForEach(i => { i.VacationDaysUsed = 0; });
            _context.BulkUpdate(yearlyVacations);
        }

        public EmployeeYearlyVacationModel GetByYearAndEmployee(int year, int employeeId)
        {
            var model = (from yv in _context.EmployeeYearlyVacations
                         join e in _context.Employees on yv.EmployeeId equals e.Id
                         where
                            yv.Year == year
                            && yv.EmployeeId == employeeId
                            && yv.State != EntityState.Deleted
                            && e.State != EntityState.Deleted
                         select new EmployeeYearlyVacationModel
                         {
                             State = yv.State,
                             EmployeeId = yv.EmployeeId,
                             Employee = e ?? new(),
                             CreatedDate = yv.CreatedDate,
                             Id = yv.Id,
                             VacationDaysUsed = yv.VacationDaysUsed,
                             Year = yv.Year,
                             YearlyVacationDays = yv.YearlyVacationDays,
                         }).FirstOrDefault();

            model ??= new EmployeeYearlyVacationModel { Year = year, EmployeeId = employeeId };
            return model;
        }

        public override IEnumerable<EmployeeYearlyVacationModel> GetAll()
        {
            var yVacations = from yv in _context.EmployeeYearlyVacations
                             join e in _context.Employees on yv.EmployeeId equals e.Id
                             where
                                yv.State != EntityState.Deleted
                                && e.State != EntityState.Deleted
                             select new EmployeeYearlyVacationModel
                             {
                                 State = yv.State,
                                 EmployeeId = yv.EmployeeId,
                                 Employee = e ?? new(),
                                 CreatedDate = yv.CreatedDate,
                                 Id = yv.Id,
                                 VacationDaysUsed = yv.VacationDaysUsed,
                                 Year = yv.Year,
                                 YearlyVacationDays = yv.YearlyVacationDays,
                             };

            return yVacations;
        }

        public override EmployeeYearlyVacationModel GetById(int id)
        {
            var yVacation = (from yv in _context.EmployeeYearlyVacations
                             join e in _context.Employees on yv.EmployeeId equals e.Id
                             where yv.Id == id
                                && yv.State != EntityState.Deleted
                                && e.State != EntityState.Deleted
                             select new EmployeeYearlyVacationModel
                             {
                                 State = yv.State,
                                 EmployeeId = yv.EmployeeId,
                                 Employee = e ?? new(),
                                 CreatedDate = yv.CreatedDate,
                                 Id = yv.Id,
                                 VacationDaysUsed = yv.VacationDaysUsed,
                                 Year = yv.Year,
                                 YearlyVacationDays = yv.YearlyVacationDays,
                             }).FirstOrDefault();

            return yVacation ?? new();
        }
    }
}
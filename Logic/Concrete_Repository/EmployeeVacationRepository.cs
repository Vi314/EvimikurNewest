using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class EmployeeVacationRepository : BaseRepository<EmployeeVacationModel>, IEmployeeVacationRepository
    {
        private readonly DataAccess.Context _context;

        public EmployeeVacationRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<EmployeeVacationModel> GetAll()
        {
            var vacations = from vacation in _context.EmployeeVacations
                            join employee in _context.Employees on vacation.EmployeeId equals employee.Id
                            where vacation.State != EntityState.Deleted
                            select new EmployeeVacationModel
                            {
                                Id = vacation.Id,
                                IsApproved = vacation.IsApproved,
                                CreatedDate = vacation.CreatedDate,
                                EmployeeId = employee.Id,
                                State = vacation.State,
                                VacationDuration = vacation.VacationDuration,
                                VacationEnd = vacation.VacationEnd,
                                VacationStart = vacation.VacationStart,
                                Employee = employee ?? new(),
                            };

            return vacations;
        }

        public override EmployeeVacationModel GetById(int id)
        {
            var entity = (from vacation in _context.EmployeeVacations
                          join employee in _context.Employees on vacation.EmployeeId equals employee.Id
                          where vacation.Id == id
                             && vacation.State != EntityState.Deleted
                             && employee.State != EntityState.Deleted
                          select new EmployeeVacationModel
                          {
                              Id = vacation.Id,
                              IsApproved = vacation.IsApproved,
                              CreatedDate = vacation.CreatedDate,
                              EmployeeId = employee.Id,
                              State = vacation.State,
                              VacationDuration = vacation.VacationDuration,
                              VacationEnd = vacation.VacationEnd,
                              VacationStart = vacation.VacationStart,
                              Employee = employee ?? new(),
                          }).FirstOrDefault();

            return entity ?? new();
        }
    }
}
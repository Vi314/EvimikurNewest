using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class EmployeeInsuranceActionRepository : BaseRepository<EmployeeInsuranceActionModel>, IEmployeeInsuranceActionRepository
    {
        private readonly DataAccess.Context _context;

        public EmployeeInsuranceActionRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<EmployeeInsuranceActionModel> GetAll()
        {
            var actions = from ea in _context.EmployeeInsuranceActions
                          join e in _context.Employees on ea.EmployeeId equals e.Id
                          where ea.State != EntityState.Deleted
                             && e.State != EntityState.Deleted
                          select new EmployeeInsuranceActionModel
                          {
                              CreatedDate = ea.CreatedDate,
                              Date = ea.Date,
                              Description = ea.Description,
                              EmployeeId = ea.EmployeeId,
                              Hospital = ea.Hospital,
                              Id = ea.Id,
                              State = ea.State,
                              Employee = e ?? new(),
                          };

            return actions;
        }

        public override EmployeeInsuranceActionModel GetById(int id)
        {
            var action = (from ea in _context.EmployeeInsuranceActions
                          join e in _context.Employees on ea.EmployeeId equals e.Id
                          where ea.Id == id
                             && ea.State != EntityState.Deleted
                             && e.State != EntityState.Deleted
                          select new EmployeeInsuranceActionModel
                          {
                              CreatedDate = ea.CreatedDate,
                              Date = ea.Date,
                              Description = ea.Description,
                              EmployeeId = ea.EmployeeId,
                              Hospital = ea.Hospital,
                              Id = ea.Id,
                              State = ea.State,
                              Employee = e ?? new(),
                          }).FirstOrDefault();
            return action ?? new();
        }
    }
}
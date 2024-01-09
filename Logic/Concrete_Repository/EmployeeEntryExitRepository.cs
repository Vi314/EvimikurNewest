using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class EmployeeEntryExitRepository : BaseRepository<EmployeeEntryExitModel>, IEmployeeEntryExitRepository
    {
        private readonly DataAccess.Context _context;

        public EmployeeEntryExitRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<EmployeeEntryExitModel> GetAll()
        {
            var entryExit = from ex in _context.EmployeeEntryExits
                            join e in _context.Employees on ex.EmployeeId equals e.Id
                            where ex.State != EntityState.Deleted
                                && e.State != EntityState.Deleted
                            select new EmployeeEntryExitModel
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

        public override EmployeeEntryExitModel GetById(int id)
        {
            var entryExit = (from ex in _context.EmployeeEntryExits
                             join e in _context.Employees on ex.EmployeeId equals e.Id
                             where ex.Id == id
                                 && ex.State != EntityState.Deleted
                                 && e.State != EntityState.Deleted
                             select new EmployeeEntryExitModel
                             {
                                 CreatedDate = ex.CreatedDate,
                                 EmployeeId = ex.EmployeeId,
                                 Employee = e,
                                 EntryTime = ex.EntryTime,
                                 ExitTime = ex.ExitTime,
                                 Id = ex.Id,
                                 State = ex.State,
                             }).FirstOrDefault();

            return entryExit ?? new();
        }
    }
}
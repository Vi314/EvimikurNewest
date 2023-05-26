using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository
{
	public class EmployeeInsuranceActionRepository : BaseRepository<EmployeeInsuranceAction>, IEmployeeInsuranceActionRepository
	{
		private readonly Context _context;

		public EmployeeInsuranceActionRepository(Context context) : base(context)
		{
			_context = context;
		}

        public override IEnumerable<EmployeeInsuranceAction> GetAll()
        {
			var actions = from ea in _context.EmployeeInsuranceActions
						 join e in _context.Employees on ea.EmployeeId equals e.Id
						 where ea.State != EntityState.Deleted
							&& e.State != EntityState.Deleted
						 select new EmployeeInsuranceAction
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

		public override EmployeeInsuranceAction GetById(int id)
		{
			var action = (EmployeeInsuranceAction)(from ea in _context.EmployeeInsuranceActions
						  join e in _context.Employees on ea.EmployeeId equals e.Id
						  where ea.Id == id
							 && ea.State != EntityState.Deleted
							 && e.State != EntityState.Deleted
						  select new EmployeeInsuranceAction
						  {
							  CreatedDate = ea.CreatedDate,
							  Date = ea.Date,
							  Description = ea.Description,
							  EmployeeId = ea.EmployeeId,
							  Hospital = ea.Hospital,
							  Id = ea.Id,
							  State = ea.State,
							  Employee = e ?? new(),
						  });

			return action;
		}
	}
}

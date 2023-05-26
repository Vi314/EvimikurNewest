using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository;

public class EmployeePaymentsRepository : BaseRepository<EmployeePayments>, IEmployeePaymentsRepository
{
    private readonly Context _context;

    public EmployeePaymentsRepository(Context context) : base(context)
    {
        _context = context;
    }
    public override IEnumerable<EmployeePayments> GetAll()
    {
        var payments = from ep in _context.EmployeePayments
                       join e in _context.Employees on ep.EmployeeId equals e.Id
                       where ep.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
                           && e.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
                       select new EmployeePayments
                       {
                           CreatedDate = ep.CreatedDate,
                           Description = ep.Description,
                           EmployeeId  = ep.EmployeeId,
                           Id = ep.Id,
                           Payment = ep.Payment,
                           PaymentDate = ep.PaymentDate,
                           State = ep.State,
                           Employee = e
                       };

         return payments;
    }

	public override EmployeePayments GetById(int id)
	{
		var payments = (EmployeePayments)(from ep in _context.EmployeePayments
					   join e in _context.Employees on ep.EmployeeId equals e.Id
					   where ep.Id == id
                           && ep.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
						   && e.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
					   select new EmployeePayments
					   {
						   CreatedDate = ep.CreatedDate,
						   Description = ep.Description,
						   EmployeeId = ep.EmployeeId,
						   Id = ep.Id,
						   Payment = ep.Payment,
						   PaymentDate = ep.PaymentDate,
						   State = ep.State,
						   Employee = e ?? new(),
					   });

		return payments;
	}
}

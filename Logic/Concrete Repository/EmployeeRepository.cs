using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
	private readonly Context _context;

	public EmployeeRepository(Context context) : base(context)
	{
		_context = context;
	}

        public override IEnumerable<Employee> GetAll()
        {
		var employees = from e in _context.Employees
                            join d in _context.Dealers on e.DealerId equals d.Id
						where e.State != EntityState.Deleted
							&& d.State != EntityState.Deleted
						select new Employee
						{
							BankBranch = e.BankBranch,
							FullAddress = e.FullAddress,
							IBAN = e.IBAN,
							CreatedDate = e.CreatedDate,
							DealerId = e.DealerId,
							Department = e.Department,
							EducationLevel = e.EducationLevel,
							FirstName = e.FirstName,
							LastName = e.LastName,
							HasHealthInsurance = e.HasHealthInsurance,
							HiredDate = e.HiredDate,
							Id = e.Id,
							State = e.State,
							TCKN = e.TCKN,
							Title = e.Title,
							Dealer = d ?? new(),
						};

            return employees;	
        }

	public override Employee GetById(int id)
	{
		var employee = (from e in _context.Employees
						join d in _context.Dealers on e.DealerId equals d.Id
						where e.Id == id
							&& e.State != EntityState.Deleted
							&& d.State != EntityState.Deleted
						select new Employee
						{
							BankBranch = e.BankBranch,
							FullAddress = e.FullAddress,
							IBAN = e.IBAN,
							CreatedDate = e.CreatedDate,
							DealerId = e.DealerId,
							Department = e.Department,
							EducationLevel = e.EducationLevel,
							FirstName = e.FirstName,
							LastName = e.LastName,
							HasHealthInsurance = e.HasHealthInsurance,
							HiredDate = e.HiredDate,
							Id = e.Id,
							State = e.State,
							TCKN = e.TCKN,
							Title = e.Title,
							Dealer = d ?? new(),
						}).FirstOrDefault();
		
		return employee;
	}
}

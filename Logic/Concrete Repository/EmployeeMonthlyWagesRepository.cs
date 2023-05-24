using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository
{
	public class EmployeeMonthlyWagesRepository : BaseRepository<EmployeeMonthlyWages>, IEmployeeMonthlyWagesRepository
	{
		private readonly Context _context;

		public EmployeeMonthlyWagesRepository(Context context) : base(context)
		{
			_context = context;
		}
	}
}

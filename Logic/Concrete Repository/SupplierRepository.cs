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
	public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
	{
		private readonly Context _context;

		public SupplierRepository(Context context) : base(context)
		{
			_context = context;
		}
	}
}

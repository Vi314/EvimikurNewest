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
	public class SaleRepository : BaseRepository<Sale>, ISaleRepository
	{
		private readonly Context _context;

		public SaleRepository(Context context) : base(context)
		{
			_context = context;
		}
	}
}

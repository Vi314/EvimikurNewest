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
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		private readonly Context _context;

		public ProductRepository(Context context) : base(context)
		{
			_context = context;
		}
	}
}

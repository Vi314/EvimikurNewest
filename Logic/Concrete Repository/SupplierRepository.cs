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
	public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
	{
		private readonly Context _context;

		public SupplierRepository(Context context) : base(context)
		{
			_context = context;
		}

        public override IEnumerable<Supplier> GetAll()
        {
			var suppliers = from s in _context.Suppliers
							where s.State != EntityState.Deleted
							select new Supplier
							{
								ApprovalState = s.ApprovalState,
								State = s.State,
								SupplierGrade = s.SupplierGrade,
								CompanyName = s.CompanyName,
								CreatedDate = s.CreatedDate,
								Id = s.Id,
							};
								
            return suppliers;
        }
    }
}

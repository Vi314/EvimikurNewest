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
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		private readonly Context _context;

		public OrderRepository(Context context) : base(context)
		{
			_context = context;
		}

        public override IEnumerable<Order> GetAll()
        {
			var orders = from o in _context.Orders
						join d in _context.Dealers on o.DealerId equals d.Id
						join s in _context.Suppliers on o.SupplierId equals s.Id
						join e in _context.Employees on o.EmployeeId equals e.Id
						where o.State != EntityState.Deleted
							&& d.State != EntityState.Deleted
							&& s.State != EntityState.Deleted
							&& e.State != EntityState.Deleted
						select new Order
						{
							State = o.State,
							Id = o.Id,
							CreatedDate = o.CreatedDate,
							Supplier = s,
							Employee = e,
							Dealer = d,
							SupplierId = o.SupplierId,
							DealerId = o.DealerId,
							OrderDate = o.OrderDate,
							EmployeeId = o.EmployeeId,
							OrderType = o.OrderType,
							Price = o.Price,
						};

            return orders;
        }
    }
}

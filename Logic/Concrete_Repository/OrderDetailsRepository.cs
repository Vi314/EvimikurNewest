using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetailsModel>, IOrderDetailsRepository
    {
        private readonly DataAccess.Context _context;

        public OrderDetailsRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<OrderDetailsModel> GetAll()
        {
            var orderDetails = from od in _context.OrderDetails
                               join o in _context.Orders on od.OrderId equals o.Id
                               join p in _context.Products on od.ProductId equals p.Id
                               where od.State != EntityState.Deleted
                                   && o.State != EntityState.Deleted
                                   && p.State != EntityState.Deleted
                               select new OrderDetailsModel
                               {
                                   Amount = od.Amount,
                                   CreatedDate = od.CreatedDate,
                                   State = od.State,
                                   Id = od.Id,
                                   Order = o,
                                   Price = od.Price,
                                   OrderId = od.OrderId,
                                   Product = p,
                                   ProductId = od.ProductId,
                               };

            return orderDetails;
        }

        public override OrderDetailsModel GetById(int id)
        {
            var orderDetails = (from od in _context.OrderDetails
                                join o in _context.Orders on od.OrderId equals o.Id
                                join p in _context.Products on od.ProductId equals p.Id
                                where od.Id == id
                                    && od.State != EntityState.Deleted
                                    && o.State != EntityState.Deleted
                                    && p.State != EntityState.Deleted
                                select new OrderDetailsModel
                                {
                                    Amount = od.Amount,
                                    CreatedDate = od.CreatedDate,
                                    State = od.State,
                                    Id = od.Id,
                                    Order = o,
                                    Price = od.Price,
                                    OrderId = od.OrderId,
                                    Product = p,
                                    ProductId = od.ProductId,
                                }).FirstOrDefault();

            return orderDetails ?? new();
        }
    }
}
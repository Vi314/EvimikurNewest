﻿using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class OrderRepository : BaseRepository<OrderModel>, IOrderRepository
    {
        private readonly DataAccess.Context _context;

        public OrderRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<OrderModel> GetAll()
        {
            var orders = from o in _context.Orders
                         join d in _context.Dealers on o.DealerId equals d.Id into sd
                         from d in sd.DefaultIfEmpty()
                         join s in _context.Suppliers on o.SupplierId equals s.Id into ss
                         from s in ss.DefaultIfEmpty()
                         join e in _context.Employees on o.EmployeeId equals e.Id into se
                         from e in se.DefaultIfEmpty()
                         where o.State != EntityState.Deleted
                             && d.State != EntityState.Deleted
                             && s.State != EntityState.Deleted
                             && e.State != EntityState.Deleted
                         select new OrderModel
                         {
                             State = o.State,
                             Id = o.Id,
                             CreatedDate = o.CreatedDate,
                             Supplier = s ?? new(),
                             Employee = e ?? new(),
                             Dealer = d ?? new(),
                             SupplierId = o.SupplierId,
                             DealerId = o.DealerId,
                             OrderDate = o.OrderDate,
                             EmployeeId = o.EmployeeId,
                             OrderType = o.OrderType,
                             Price = o.Price,
                         };

            return orders;
        }

        public override OrderModel GetById(int id)
        {
            var order = (from o in _context.Orders
                         join d in _context.Dealers on o.DealerId equals d.Id into sd
                         from d in sd.DefaultIfEmpty()
                         join s in _context.Suppliers on o.SupplierId equals s.Id into ss
                         from s in ss.DefaultIfEmpty()
                         join e in _context.Employees on o.EmployeeId equals e.Id into se
                         from e in se.DefaultIfEmpty()
                         where o.Id == id
                              && o.State != EntityState.Deleted
                              && d.State != EntityState.Deleted
                              && s.State != EntityState.Deleted
                              && e.State != EntityState.Deleted
                         select new OrderModel
                         {
                             State = o.State,
                             Id = o.Id,
                             CreatedDate = o.CreatedDate,
                             Supplier = s ?? new(),
                             Employee = e ?? new(),
                             Dealer = d ?? new(),
                             SupplierId = o.SupplierId,
                             DealerId = o.DealerId,
                             OrderDate = o.OrderDate,
                             EmployeeId = o.EmployeeId,
                             OrderType = o.OrderType,
                             Price = o.Price,
                         }).FirstOrDefault();

            return order ?? new();
        }
    }
}
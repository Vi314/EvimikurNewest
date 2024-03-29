﻿using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class DealerStocksRepository : BaseRepository<DealerStocksModel>, IDealerStocksRepository
    {
        private readonly DataAccess.Context _context;

        public DealerStocksRepository(DataAccess.Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<DealerStocksModel> GetAll()
        {
            var stocks = from st in _context.DealerStocks
                         join d in _context.Dealers on st.DealerId equals d.Id into sd
                         from d in sd.DefaultIfEmpty()
                         join p in _context.Products on st.ProductId equals p.Id into sp
                         from p in sp.DefaultIfEmpty()
                         join su in _context.Suppliers on st.SupplierId equals su.Id into ssu
                         from su in ssu.DefaultIfEmpty()
                         where st.State != EntityState.Deleted
                             && d.State != EntityState.Deleted
                             && p.State != EntityState.Deleted
                             && su.State != EntityState.Deleted
                         select new DealerStocksModel
                         {
                             Amount = st.Amount,
                             MinimumAmount = st.MinimumAmount,
                             Cost = st.Cost,
                             CreatedDate = st.CreatedDate,
                             DealerId = st.DealerId,
                             Id = st.Id,
                             Product = p ?? new(),
                             Dealer = d ?? new(),
                             Supplier = su ?? new(),
                             ProductId = st.ProductId,
                             SalesPrice = st.SalesPrice,
                             State = st.State,
                             SupplierId = st.SupplierId,
                         };
            return stocks;
        }

        public override DealerStocksModel GetById(int id)
        {
            var stock = (from st in _context.DealerStocks
                         join d in _context.Dealers on st.DealerId equals d.Id into sd
                         from d in sd.DefaultIfEmpty()
                         join p in _context.Products on st.ProductId equals p.Id into sp
                         from p in sp.DefaultIfEmpty()
                         join su in _context.Suppliers on st.SupplierId equals su.Id into ssu
                         from su in ssu.DefaultIfEmpty()
                         where st.Id == id
                             && st.State != EntityState.Deleted
                             && d.State != EntityState.Deleted
                             && p.State != EntityState.Deleted
                             && su.State != EntityState.Deleted
                         select new DealerStocksModel
                         {
                             Amount = st.Amount,
                             MinimumAmount = st.MinimumAmount,
                             Cost = st.Cost,
                             CreatedDate = st.CreatedDate,
                             DealerId = st.DealerId,
                             Id = st.Id,
                             Product = p ?? new(),
                             Dealer = d ?? new(),
                             Supplier = su ?? new(),
                             ProductId = st.ProductId,
                             SalesPrice = st.SalesPrice,
                             State = st.State,
                             SupplierId = st.SupplierId,
                         }).FirstOrDefault();
            return stock ?? new();
        }
    }
}
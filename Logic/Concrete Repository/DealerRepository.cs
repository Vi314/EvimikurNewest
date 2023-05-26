using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
    public class DealerRepository : BaseRepository<Dealer>, IDealerRepository
    {
        private readonly Context _context;

        public DealerRepository(Context context) : base(context)
        {
            _context = context;
        }
        public override IEnumerable<Dealer> GetAll()
        {
            var dealers = from dealer in _context.Dealers
                          where dealer.State != EntityState.Deleted
                          select new Dealer
                          {
                              Id = dealer.Id,
                              CreatedDate = dealer.CreatedDate,
                              State = dealer.State,
                              FullAdress = dealer.FullAdress,
                              Name = dealer.Name,
                              ProductPrices = (from pp in _context.ProductPrices
                                               join pd in _context.ProductPriceAndDealers on pp.Id equals pd.ProductPriceId into spd
                                               from pd in spd.DefaultIfEmpty()
                                               where pd.DealerId == dealer.Id
                                               select new ProductPrice
                                               {
                                                   CreatedDate = pp.CreatedDate,
                                                   State = pp.State,
                                                   SellingPrice = pp.SellingPrice,
                                                   Id = pp.Id,
                                                   IsDiscounted = pp.IsDiscounted,
                                                   ProductId = pp.ProductId,
                                                   ProductionPrice = pp.ProductionPrice,
                                                   TaxPrice = pp.TaxPrice,
                                                   ValidUntil = pp.ValidUntil,
                                               }).ToList(),
                              Sales = (from s in _context.Sales
                                       join sd in _context.SalesAndDealers on s.Id equals sd.SaleId into ssd 
                                       from sd in ssd.DefaultIfEmpty()
                                       where sd.DealerId == dealer.Id
                                       select new Sale
                                       {
                                           StartDate = s.StartDate,
                                           State = s.State,
                                           CreatedDate = s.CreatedDate,
                                           Description = s.Description,
                                           Discount = s.Discount,
                                           EndDate = s.EndDate,
                                           Id = s.Id,
                                           IsForAllDealers = s.IsForAllDealers,
                                           IsForAllProducts = s.IsForAllProducts,
                                       }).ToList()
                          };

            return dealers;
        }
        public override Dealer GetById(int id)
        {
            return base.GetById(id);
        }
    }
}

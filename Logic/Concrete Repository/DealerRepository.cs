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
            //TODO IMPLEMENT A WAY TO RETRIEVE LIST<ENTITY> WITH A QUERY (I THINK SUBQUERY IS THE ONLY WAY)
            var dealers = from dealer in _context.Dealers
                          join sd in _context.SalesAndDealers on dealer.Id equals sd.DealerId
                          join s in _context.Sales on sd.SaleId equals s.Id
                          join pd in _context.ProductPriceAndDealers on dealer.Id equals pd.DealerId
                          join p in _context.Products on pd.ProductPriceId equals p.Id
                          where dealer.State != EntityState.Deleted
                            && sd.State != EntityState.Deleted
                            && pd.State != EntityState.Deleted
                          select new Dealer
                          {
                              Id = dealer.Id,
                              CreatedDate = dealer.CreatedDate,
                              State = dealer.State,
                              FullAdress = dealer.FullAdress,
                              Name = dealer.Name,
                              ProductPrices = (from productPrice in _context.ProductPrices
                                               join pd in _context.ProductPriceAndDealers on productPrice.Id equals pd.ProductPriceId
                                               where pd.DealerId == dealer.Id
                                               select productPrice).ToList(),
                              Sales = (from s in _context.Sales
                                       join sd in _context.SalesAndDealers on s.Id equals sd.SaleId
                                       where sd.DealerId == dealer.Id
                                       select s).ToList()
                          };

            return dealers;
        }
        public override Dealer GetById(int id)
        {
            return base.GetById(id);
        }
    }
}

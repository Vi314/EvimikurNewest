﻿using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository;

public class DealerRepository : BaseRepository<DealerModel>, IDealerRepository
{
    private readonly DataAccess.Context _context;

    public DealerRepository(DataAccess.Context context) : base(context)
    {
        _context = context;
    }

    public override IEnumerable<DealerModel> GetAll()
    {
        var dealers = from dealer in _context.Dealers
                      where dealer.State != EntityState.Deleted
                      select new DealerModel
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
                                           select new ProductPriceModel
                                           {
                                               CreatedDate = pp.CreatedDate,
                                               State = pp.State,
                                               SellingPrice = pp.SellingPrice,
                                               Id = pp.Id,
                                               ProductId = pp.ProductId,
                                               ProductionPrice = pp.ProductionPrice,
                                               TaxPrice = pp.TaxPrice,
                                               ValidUntil = pp.ValidUntil,
                                           }).ToList(),
                          Sales = (from s in _context.Sales
                                   join sd in _context.SalesAndDealers on s.Id equals sd.SaleId into ssd
                                   from sd in ssd.DefaultIfEmpty()
                                   where sd.DealerId == dealer.Id
                                   select new SaleModel
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

    public override DealerModel GetById(int id)
    {
        var dealer = (from d in _context.Dealers
                      where d.Id == id
                  && d.State != EntityState.Deleted
                      select new DealerModel
                      {
                          Id = d.Id,
                          CreatedDate = d.CreatedDate,
                          State = d.State,
                          FullAdress = d.FullAdress,
                          Name = d.Name,
                          ProductPrices = (from pp in _context.ProductPrices
                                           join pd in _context.ProductPriceAndDealers on pp.Id equals pd.ProductPriceId into spd
                                           from pd in spd.DefaultIfEmpty()
                                           where pd.DealerId == d.Id
                                           select new ProductPriceModel
                                           {
                                               CreatedDate = pp.CreatedDate,
                                               State = pp.State,
                                               SellingPrice = pp.SellingPrice,
                                               Id = pp.Id,
                                               ProductId = pp.ProductId,
                                               ProductionPrice = pp.ProductionPrice,
                                               TaxPrice = pp.TaxPrice,
                                               ValidUntil = pp.ValidUntil,
                                           }).ToList(),
                          Sales = (from s in _context.Sales
                                   join sd in _context.SalesAndDealers on s.Id equals sd.SaleId into ssd
                                   from sd in ssd.DefaultIfEmpty()
                                   where sd.DealerId == d.Id
                                   select new SaleModel
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
                      }).FirstOrDefault();

        return dealer ?? new();
    }
}
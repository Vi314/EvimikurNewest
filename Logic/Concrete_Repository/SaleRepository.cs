using DataAccess;
using Entity.ConnectionEntity;
using Entity.Entity;
using Logic.Abstract_Generic;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Logic.Concrete_Repository;

public class SaleRepository : BaseRepository<SaleModel>, ISaleRepository
{
    private readonly Context _context;
    private readonly IEntityDetailsManager<SalesAndProductsModel> _productConnections;
    private readonly IEntityConnectionManager<SalesAndDealersModel> _dealerConnections;

    public SaleRepository(Context context,
                          IEntityDetailsManager<SalesAndProductsModel> productConnections,
                          IEntityConnectionManager<SalesAndDealersModel> dealerConnections) : base(context)
    {
        _context = context;
        
        _productConnections = productConnections;

        dealerConnections.ConnectionPropertyName = nameof(SalesAndDealersModel.DealerId);
        dealerConnections.MainPropertyName = nameof(SalesAndDealersModel.SaleId);
        _dealerConnections = dealerConnections;
    }

    public override HttpStatusCode Create(SaleModel sale)
    {
        var result = base.Create(sale);  
        _productConnections.BulkCreateDetails(sale.Products.Select(x => new SalesAndProductsModel { HeaderId = sale.Id, DetailId = x.Id }).ToList());
        _dealerConnections.CreateConnections(sale.Id, sale.Dealers.Select(x => x.Id).ToList());
        _context.BulkSaveChanges();

        return result;
    }

    public override HttpStatusCode Update(SaleModel sale)
    {   
        var result = base.Update(sale);
        _productConnections.BulkUpdateDetails(sale.Products.Select(x => new SalesAndProductsModel { HeaderId = sale.Id, DetailId = x.Id }).ToList());
        //_dealerConnections.UpdateConnections(sale.Id, sale.Dealers.Select(x => x.Id).ToList());

        return result;
    }

    public override HttpStatusCode Delete(int id)
    {
        var result = base.Delete(id);
        _dealerConnections.DeleteConnections(id);
        _productConnections.BulkDeleteDetails(id);
        
        return result;
    }

    public override IEnumerable<SaleModel> GetAll()
    {
        var sales = from s in _context.Sales
                    where s.State != EntityState.Deleted
                    select new SaleModel
                    {
                        State = s.State,
                        IsForAllDealers = s.IsForAllDealers,
                        StartDate = s.StartDate,
                        CreatedDate = s.CreatedDate,
                        Description = s.Description,
                        Discount = s.Discount,
                        EndDate = s.EndDate,
                        Id = s.Id,
                        IsForAllProducts = s.IsForAllProducts,
                        Dealers = (from d in _context.Dealers
                                   join ds in _context.SalesAndDealers on d.Id equals ds.DealerId
                                   where ds.SaleId == s.Id && d.State != EntityState.Deleted && ds.State != EntityState.Deleted
                                   select new DealerModel
                                   {
                                       CreatedDate = d.CreatedDate,
                                       State = d.State,
                                       FullAdress = d.FullAdress,
                                       Name = d.Name,
                                       Id = d.Id,
                                   }).ToList() ?? new(),
                        Products = (from p in _context.Products
                                    join ps in _context.SalesAndProducts on p.Id equals ps.DetailId
                                    where ps.HeaderId == s.Id && ps.State != EntityState.Deleted && p.State != EntityState.Deleted
                                    select new ProductModel
                                    {
                                        CreatedDate = p.CreatedDate,
                                        ProductName = p.ProductName,
                                        Description = p.Description,
                                        State = p.State,
                                        Id = p.Id,
                                        CategoryId = p.CategoryId,
                                        FunctionalityGrade = p.FunctionalityGrade,
                                        PriceAdvantageGrade = p.PriceAdvantageGrade,
                                        PotentialSalesGrade = p.PotentialSalesGrade,
                                        LooksGrade = p.LooksGrade,
                                        InnovativeGrade = p.InnovativeGrade,
                                        UsabilityGrade = p.UsabilityGrade,
                                    }).ToList() ?? new(),
                    };

        return sales;
    }

    public override SaleModel GetById(int id)
    {
        var sale = (from s in _context.Sales
                    where s.Id == id
                    && s.State != EntityState.Deleted
                    select new SaleModel
                    {
                        State = s.State,
                        IsForAllDealers = s.IsForAllDealers,
                        StartDate = s.StartDate,
                        CreatedDate = s.CreatedDate,
                        Description = s.Description,
                        Discount = s.Discount,
                        EndDate = s.EndDate,
                        Id = s.Id,
                        IsForAllProducts = s.IsForAllProducts,
                        Dealers = (from d in _context.Dealers
                                   join ds in _context.SalesAndDealers on d.Id equals ds.DealerId
                                   where ds.SaleId == s.Id && d.State != EntityState.Deleted && ds.State != EntityState.Deleted
                                   select new DealerModel
                                   {
                                       CreatedDate = d.CreatedDate,
                                       State = d.State,
                                       FullAdress = d.FullAdress,
                                       Name = d.Name,
                                       Id = d.Id,
                                   }).ToList() ?? new(),
                        Products = (from p in _context.Products
                                    join ps in _context.SalesAndProducts on p.Id equals ps.DetailId
                                    where ps.HeaderId == s.Id && ps.State != EntityState.Deleted && p.State != EntityState.Deleted
                                    select new ProductModel
                                    {
                                        CreatedDate = p.CreatedDate,
                                        ProductName = p.ProductName,
                                        Description = p.Description,
                                        State = p.State,
                                        Id = p.Id,
                                        CategoryId = p.CategoryId,
                                        FunctionalityGrade = p.FunctionalityGrade,
                                        PriceAdvantageGrade = p.PriceAdvantageGrade,
                                        PotentialSalesGrade = p.PotentialSalesGrade,
                                        LooksGrade = p.LooksGrade,
                                        InnovativeGrade = p.InnovativeGrade,
                                        UsabilityGrade = p.UsabilityGrade,
                                    }).ToList() ?? new(),
                    }).FirstOrDefault();

        return sale ?? new();
    }
}
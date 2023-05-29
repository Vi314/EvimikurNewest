using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository;

public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    private readonly Context _context;

    public SaleRepository(Context context) : base(context)
    {
        _context = context;
    }
	public HttpStatusCode Update(Sale sale, List<int> dealerids, List<int> productids)
	{
		throw new NotImplementedException();
	}
	public override HttpStatusCode Delete(int id)
	{
		return base.Delete(id);	
	}
	public HttpStatusCode Create(Sale sale, List<int> dealerids, List<int> productids)
	{
		var result = base.Create(sale);
		CreateDealerConnections(sale.Id, dealerids);
		CreateProductConnections(sale.Id, productids);

		return result;
	}

	public void CreateDealerConnections(int id, List<int> dealerids)
	{
		foreach (var i in dealerids)
		{
			var z = new SalesAndDealers
			{
				DealerId = i,
				SaleId = i,
			};
			_context.Add(z);
		}
	}
	public void UpdateDealerConnections(int id, List<int> dealerids)
	{
		foreach (var i in dealerids)
		{

		}
	}
	public void DeleteDealerConnections(int id)
	{
		throw new NotImplementedException();
	}

	public void CreateProductConnections(int id, List<int> productids)
	{
		foreach (var i in productids)
		{
			var z = new SalesAndProducts
			{
				ProductId = i,
				SaleId = i,
			};
			_context.Add(z);
		}
	}
	public void UpdateProductConnections(int id, List<int> productids)
	{
		throw new NotImplementedException();
	}
	public void DeleteProductConnections(int id)
	{
		throw new NotImplementedException();
	}

	public override IEnumerable<Sale> GetAll()
    {
		var sales = from s in _context.Sales
					where s.State != EntityState.Deleted
					select new Sale
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
								   select new Dealer
								   {
									   CreatedDate = d.CreatedDate,
									   State = d.State,
									   FullAdress = d.FullAdress,
									   Name = d.Name,
									   Id = d.Id,
								   }).ToList() ?? new(),
						Products = (from p in _context.Products
									join ps in _context.SalesAndProducts on p.Id equals ps.ProductId
									where ps.SaleId == s.Id && ps.State != EntityState.Deleted && p.State != EntityState.Deleted
									select new Product
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
	public override Sale GetById(int id)
	{
		var sale = (from s in _context.Sales
					where s.Id == id 
                    && s.State != EntityState.Deleted
					select new Sale
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
								   select new Dealer
								   {
									   CreatedDate = d.CreatedDate,
									   State = d.State,
									   FullAdress = d.FullAdress,
									   Name = d.Name,
									   Id = d.Id,
								   }).ToList() ?? new(),
						Products = (from p in _context.Products
									join ps in _context.SalesAndProducts on p.Id equals ps.ProductId
									where ps.SaleId == s.Id && ps.State != EntityState.Deleted && p.State != EntityState.Deleted
									select new Product
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

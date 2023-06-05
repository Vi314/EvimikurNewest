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

public class SaleRepository : BaseRepository<SaleModel>, ISaleRepository
{
	private readonly Context _context;
    private readonly ITestRepo<SaleModel, SalesAndProductsModel> _productConnections;
    private readonly ITestRepo<SaleModel, SalesAndDealersModel> _dealerConnections;


    public SaleRepository(Context context,
						  ITestRepo<SaleModel, SalesAndProductsModel> productConnections,
                          ITestRepo<SaleModel, SalesAndDealersModel> dealerConnections) : base(context)
	{
		_context = context;

        productConnections.ConnectionPropertyName = nameof(SalesAndProductsModel.ProductId);
        productConnections.MainPropertyName = nameof(SalesAndProductsModel.SaleId);
		_productConnections = productConnections;

        dealerConnections.ConnectionPropertyName = nameof(SalesAndDealersModel.DealerId);
        dealerConnections.MainPropertyName = nameof(SalesAndDealersModel.SaleId);
		_dealerConnections = dealerConnections;
    }

    public HttpStatusCode Create(SaleModel sale, List<int> dealerids, List<int> productids)
	{
        base.Create(sale);
        _productConnections.CreateConnections(sale.Id, productids);
        _dealerConnections.CreateConnections(sale.Id, dealerids);
        _context.BulkSaveChanges();

        return HttpStatusCode.OK;
    }

    //var newDealerConnections = dealerids.Select(x => new SalesAndDealersModel { DealerId = x, SaleId = sale.Id });
    //var newProductConnections = productids.Select(x => new SalesAndProductsModel { ProductId = x, SaleId = sale.Id });

    //_context.BulkInsert(newDealerConnections);
    //_context.BulkInsert(newProductConnections);

    public HttpStatusCode Update(SaleModel sale, List<int> dealerids, List<int> productids)
	{
		var result = base.Update(sale);
		UpdateDealerConnections(sale.Id, dealerids);
		UpdateProductConnections(sale.Id, productids);

		return result;
	}

	/// <summary>
	///  Salein dealer bağlantılarını gönderilen dealerId listesine göre düzenler
	/// </summary>
	/// <param name="id">Sale Model Id</param>
	/// <param name="dealerids">Dealer Id list</param>
	public void UpdateDealerConnections(int id, List<int> dealerids)
	{
		var existingConnections = _context.SalesAndDealers
			.Where(x => x.SaleId == id && x.State != EntityState.Deleted)
			.ToList();

		var connectionsToDelete = existingConnections
			.Where(x => !dealerids.Contains(x.DealerId)).ToList();

		var newConnections = dealerids
			.Where(x => existingConnections.FirstOrDefault(y => y.DealerId == x) == null)
			.Select(x => new SalesAndDealersModel { SaleId = id, DealerId = x });

		_context.SalesAndDealers.BulkDelete(connectionsToDelete);
		_context.SalesAndDealers.BulkInsert(newConnections);
		_context.BulkSaveChanges();
	}

	public void UpdateProductConnections(int id, List<int> productids)
	{
		var existingConnections = _context.SalesAndProducts
			.Where(x => x.SaleId == id && x.State != EntityState.Deleted)
			.ToList();

		var connectionsToDelete = existingConnections
			.Where(x => !productids.Contains(x.ProductId)).ToList();

		var newConnections = productids
			.Where(x => existingConnections.FirstOrDefault(y => y.ProductId == x) == null)
			.Select(x => new SalesAndProductsModel { SaleId = id, ProductId = x });

		_context.SalesAndProducts.BulkDelete(connectionsToDelete);
		_context.SalesAndProducts.BulkInsert(newConnections);
		_context.BulkSaveChanges();
	}


	public override HttpStatusCode Delete(int id)
	{
		var dealerConnections = _context.SalesAndDealers.Where(x => x.SaleId == id && x.State != EntityState.Deleted);
		var productConnections = _context.SalesAndProducts.Where(x => x.SaleId == id && x.State != EntityState.Deleted);
		var result = base.Delete(id);

		_context.BulkDelete(dealerConnections);
		_context.BulkDelete(productConnections);
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
									join ps in _context.SalesAndProducts on p.Id equals ps.ProductId
									where ps.SaleId == s.Id && ps.State != EntityState.Deleted && p.State != EntityState.Deleted
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
									join ps in _context.SalesAndProducts on p.Id equals ps.ProductId
									where ps.SaleId == s.Id && ps.State != EntityState.Deleted && p.State != EntityState.Deleted
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

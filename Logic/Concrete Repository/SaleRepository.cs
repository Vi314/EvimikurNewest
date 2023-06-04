﻿using DataAccess;
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

	public SaleRepository(Context context) : base(context)
	{
		_context = context;
	}

	public HttpStatusCode Create(SaleModel sale, List<int> dealerids, List<int> productids)
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
			_context.Add(new SalesAndDealersModel { DealerId = i, SaleId = id });
		}
	}
	public void CreateProductConnections(int id, List<int> productids)
	{
		foreach (var i in productids)
		{
			_context.Add(new SalesAndProductsModel { ProductId = i, SaleId = id });
		}
	}


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
		//Önce Sale'a bağlı Dealer bağlantılarını getirir
		var saleAndDealerList = _context.SalesAndDealers.Where(x => x.SaleId == id && x.State != EntityState.Deleted).ToList();

		//Gönderilen listeden silinmiş olan DealerId'lerin bağlantılarını siler
		foreach (var saleAndDealer in saleAndDealerList)
		{
			var containsDealerId = dealerids.Contains(saleAndDealer.DealerId);
			if (!containsDealerId)
			{
				saleAndDealer.State = EntityState.Deleted;
			}
		}

		//Gönderilen listeye yeni eklenmiş olan DealerId'lerin bağlantılarını ekler
		foreach (var dealerId in dealerids)
		{
			var salesAndDealer = saleAndDealerList.FirstOrDefault(x => x.DealerId == dealerId) == null;
			if (salesAndDealer)
			{
				_context.SalesAndDealers.Add(new SalesAndDealersModel { SaleId = id, DealerId = dealerId });
			}
		}

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
			.Select(newId => new SalesAndProductsModel { SaleId = id, ProductId = newId });

		_context.SalesAndProducts.BulkDelete(connectionsToDelete);
		_context.SalesAndProducts.BulkInsert(newConnections);
		_context.BulkSaveChanges();
	}

	public void DeleteProductConnections(int id)
	{
		throw new NotImplementedException();
	}
	public void DeleteDealerConnections(int id)
	{
		throw new NotImplementedException();
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

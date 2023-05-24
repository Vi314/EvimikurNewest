using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Logic.Concrete_Service;

public class SaleService : ISaleService
{
	private readonly ISaleRepository _repository;
	private readonly IDealerService _dealerService;
	private readonly IProductService _productService;
	private readonly ISalesAndDealersService _salesAndDealersService;

	public SaleService(ISaleRepository repository, 
					   IDealerService dealerService, 
					   IProductService productService,
					   ISalesAndDealersService salesAndDealersService)
	{
		_repository = repository;
		_dealerService = dealerService;
		_productService = productService;
		_salesAndDealersService = salesAndDealersService;
	}

	public HttpStatusCode CreateOne(Sale sale, List<int> dealerId, List<int> productId)
	{
		try
		{
			var result = _repository.Create(sale);
			
			if (sale.IsForAllDealers)
			{
				//dealerId = IsForall(dealerId);
			}
			foreach (var id in dealerId)
			{
				_repository.ExecuteRawSql($"INSERT INTO SalesAndDealers (dealerId, saleId) VALUES ({id},{sale.Id})");
			}

			if (sale.IsForAllProducts)
			{
				var products = _productService.GetProducts();
				if (productId == null)
				{
					productId = new List<int>();
				}
				productId.Clear();
				foreach (var product in products) 
				{
					productId.Add(product.Id);
				}
			}
			foreach (var id in productId)
			{
				_repository.ExecuteRawSql($"INSERT INTO SalesAndProducts (productId, saleId) VALUES ({id},{sale.Id})");
			}

			return result;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return HttpStatusCode.BadRequest;
		}
	}

	public HttpStatusCode CreateRange(IEnumerable<Sale> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteOne(int id)
	{
		try
		{
			return _repository.Delete(id);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return HttpStatusCode.BadRequest;
		}
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<Sale> GetAll()
	{
		return _repository.GetAll();
	}

	public Sale GetById(int id)
	{
		return _repository.GetById(id);
	}

	public HttpStatusCode UpdateOne(Sale sale, List<int> dealerId, List<int> productId)
	{
		try
		{
			var dealersConnectedToSale = _salesAndDealersService.GetAll(sale.Id).ToList();
			foreach (var id in dealerId)
			{
				foreach (var saleDealer in dealersConnectedToSale)
				{
					if (saleDealer.DealerId == id)
					{
						dealerId.Remove(id);
					}
				}
			}

			foreach (var item in dealersConnectedToSale)
			{
				foreach (var id in dealerId)
				{
				}
			}

			foreach (var item in dealerId)
			{

			}




			return HttpStatusCode.BadRequest;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return HttpStatusCode.BadRequest;
		}
	}

	public HttpStatusCode UpdateRange(IEnumerable<Sale> Thing)
	{
		throw new NotImplementedException();
	}
}

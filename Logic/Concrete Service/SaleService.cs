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
	private readonly ISalesAndDealersService _salesAndDealers;
	private readonly ISalesAndProductsService _salesAndProducts;

	public SaleService(ISaleRepository repository,
					   ISalesAndDealersService salesAndDealers,
					   ISalesAndProductsService salesAndProducts)
	{
		_repository = repository;
		_salesAndDealers = salesAndDealers;
		_salesAndProducts = salesAndProducts;
	}

	public HttpStatusCode CreateOne(Sale sale, List<int> dealerId, List<int> productId)
	{
		try
		{
			var result = _repository.Create(sale);
			foreach (var i in dealerId)
			{
				_salesAndDealers.Create(new SalesAndDealers { DealerId = i,SaleId = sale.Id});
			}
			foreach (var i in productId)
			{
				_salesAndProducts.Create(new SalesAndProducts { ProductId = i, SaleId = sale.Id });
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
			//TODO Make sense of updating the n to n connection tables through the sale
			
			var result = _repository.Update(sale);

			var dealerSale = _salesAndDealers.GetAll(sale.Id);
			foreach (var i in dealerSale)
			{
				bool test = false;
				foreach (var z in dealerId)
				{
					if (i.DealerId == z)
					{
						test = true;
					}
				}

				if (!test)
				{
					_salesAndDealers.Delete(i.Id);
					continue;
				}

				//TODO HAVE NOT IMPLEMENTED CREATING THE ADDITIONAL DEALER OR PRODUCT CONNECTIONS THAT MAY HAVE BEEN MADE
			}

			var productSale = _salesAndProducts.GetAll(sale.Id);
			foreach (var i in productSale)
			{
				bool test = false;
				foreach (var z in productId)
				{
					if (i.ProductId == z)
					{
						test = true;
					}
				}

				if (!test)
				{
					_salesAndProducts.Delete(i.Id);
					continue;
				}

			}

			return result;
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

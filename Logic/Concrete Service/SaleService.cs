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

	public SaleService(ISaleRepository repository)
	{
		_repository = repository;
	}

	public HttpStatusCode CreateOne(SaleModel sale, List<int> dealerId, List<int> productId)
	{
		try
		{

			var result = _repository.Create(sale, dealerId, productId);
			return result;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return HttpStatusCode.BadRequest;
		}
	}

	public HttpStatusCode CreateRange(IEnumerable<SaleModel> Thing)
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

	public IEnumerable<SaleModel> GetAll()
	{
		return _repository.GetAll();
	}

	public SaleModel GetById(int id)
	{
		return _repository.GetById(id);
	}

	public HttpStatusCode UpdateOne(SaleModel sale, List<int> dealerId, List<int> productId)
	{
		return _repository.Update(sale, dealerId, productId);

		//try
		//{
		//	//TODO Make sense of updating the n to n connection tables through the sale
			
		//	var result = _repository.Update(sale);
		//	var dealerSale = _salesAndDealers.GetAll(sale.Id);
			

		//	foreach (var i in dealerSale)
		//	{
		//		bool test = false;
		//		foreach (var z in dealerId)
		//		{
		//			if (i.DealerId == z)
		//			{
		//				test = true;
		//			}
		//		}

		//		if (!test)
		//		{
		//			_salesAndDealers.Delete(i.Id);	
		//			continue;
		//		}

		//		//TODO HAVE NOT IMPLEMENTED CREATING THE ADDITIONAL DEALER OR PRODUCT CONNECTIONS THAT MAY HAVE BEEN MADE
		//	}
  //          foreach (var x in dealerId)
  //          {
  //              bool test = false;
  //              foreach (var y in dealerSale)
  //              {
  //                  if (y.DealerId == x)
  //                  {
  //                      test = true;
  //                  }
  //              }

  //              if (!test)
  //              {
		//			var e = new SalesAndDealersModel
		//			{
		//				DealerId = x,
		//				SaleId = sale.Id,
		//			};
  //                  _salesAndDealers.Create(e);
  //                  continue;
  //              }

  //          }
  //          var productSale = _salesAndProducts.GetAll(sale.Id);
		//	foreach (var i in productSale)
		//	{
		//		bool test = false;
		//		foreach (var z in productId)
		//		{
		//			if (i.ProductId == z)
		//			{
		//				test = true;
		//			}
		//		}

		//		if (!test)
		//		{
		//			_salesAndProducts.Delete(i.Id);
		//			continue;
		//		}

		//	}

		//	return result;
		//}
		//catch (Exception e)
		//{
		//	Console.WriteLine(e);
		//	return HttpStatusCode.BadRequest;
		//}
	}
	public HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing)
	{
		throw new NotImplementedException();
	}
}

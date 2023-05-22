using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service;

public class SaleService : ISaleService
{
	private readonly ISaleRepository _repository;
	private readonly IDealerService _dealerService;
	private readonly IProductService _productService;

	public SaleService(ISaleRepository repository, IDealerService dealerService, IProductService productService)
	{
		_repository = repository;
		_dealerService = dealerService;
		_productService = productService;
	}

	public string CreateOne(Sale sale, List<int> dealerId, List<int> productId)
	{
		try
		{
			var result = _repository.Create(sale);
			
			if (sale.IsForAllDealers)
			{
				var dealers = _dealerService.GetDealers();
				if (dealerId == null)
				{
					dealerId = new List<int>();
				}
				dealerId.Clear();
				foreach (var dealer in dealers)
				{
					dealerId.Add(dealer.Id);
				}
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
			return e.ToString();
		}
	}

	public string DeleteOne(int id)
	{
		try
		{
			return _repository.Delete(id);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return e.ToString();
		}
	}

	public IEnumerable<Sale> GetAll()
	{
		return _repository.GetAll();
	}

	public Sale GetById(int id)
	{
		return _repository.GetById(id);
	}

	public string UpdateOne(Sale sale, List<int> dealerId, List<int> productId)
	{
		try
		{
			return _repository.Update(sale);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return e.ToString();
		}
	}

}

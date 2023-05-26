﻿using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service
{
	public class ProductPriceAndDealersService : IProductPriceAndDealersService
	{
		private readonly IProductPriceAndDealersRepository _repository;

		public ProductPriceAndDealersService(IProductPriceAndDealersRepository repository)
		{
			_repository = repository;
		}

		public HttpStatusCode CreateOne(ProductPriceAndDealers thing)
		{
			try
			{
				return _repository.Create(thing);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpStatusCode.BadRequest;
			}
		}

		public HttpStatusCode CreateRange(IEnumerable<ProductPriceAndDealers> Thing)
		{
			try
			{
				return _repository.CreateRange(Thing);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpStatusCode.BadRequest;
			}
		}

		public HttpStatusCode DeleteOne(int id)
		{
			try 
			{ 
				return _repository.Delete(id);
					} 
			catch (Exception e) 
			{ Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public HttpStatusCode DeleteRange(IEnumerable<int> id)
		{
			try { return _repository.DeleteRange(id); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public IEnumerable<ProductPriceAndDealers> GetAll()
		{
			try { return _repository.GetAll(); } catch (Exception e) { Console.WriteLine(e); throw; }
		}

		public ProductPriceAndDealers GetById(int id)
		{
			try { return _repository.GetById(id); } catch (Exception e) { Console.WriteLine(e); throw; }
		}

		public HttpStatusCode UpdateOne(ProductPriceAndDealers thing)
		{
			try { return _repository.Update(thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public HttpStatusCode UpdateRange(IEnumerable<ProductPriceAndDealers> Thing)
		{
			try { return _repository.UpdateRange(Thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

	}
}
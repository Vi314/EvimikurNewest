using System.Net;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service
{
	public class SalesAndDealersService : ISalesAndDealersService
	{
		private readonly ISalesAndDealersRepository _repository;

		public SalesAndDealersService(ISalesAndDealersRepository repository)
        {
			_repository = repository;
		}

		public HttpStatusCode Create(SalesAndDealers salesAndDealers)
		{
			try
			{
				return _repository.Create(salesAndDealers);
			}
			catch (Exception e)
			{
                Console.WriteLine(e);
				return HttpStatusCode.BadRequest;
			}
		}

		public HttpStatusCode CreateRange(IEnumerable<SalesAndDealers> Thing)
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

		public HttpStatusCode Delete(int id)
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
			try
			{
				return _repository.DeleteRange(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpStatusCode.BadRequest;
			}
		}

		public IEnumerable<SalesAndDealers> GetAll()
		{
			try
			{
				return _repository.GetAll();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new List<SalesAndDealers>();
			}
		}

		public IEnumerable<SalesAndDealers> GetAll(int saleId)
		{
			try
			{
				return _repository.GetAll(saleId);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new List<SalesAndDealers>();
			}
		}

		public SalesAndDealers GetById(int id)
		{
			try
			{
				return _repository.GetById(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new SalesAndDealers();
			}
		}

		public HttpStatusCode Update(SalesAndDealers salesAndDealers)
		{
			try
			{
				return _repository.Update(salesAndDealers);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpStatusCode.BadRequest;
			}
		}

		public HttpStatusCode UpdateRange(IEnumerable<SalesAndDealers> Thing)
		{
			try
			{
				return _repository.UpdateRange(Thing);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return HttpStatusCode.BadRequest;
			}
		}
	}
}

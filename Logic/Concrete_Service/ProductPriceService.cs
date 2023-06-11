using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service
{
	public class ProductPriceService : IProductPriceService
	{
		private readonly IProductPriceRepository _repository;

		public ProductPriceService(IProductPriceRepository repository)
		{
			_repository = repository;
		}

		public HttpStatusCode CreateOne(ProductPriceModel thing, IEnumerable<int> dealerIds)
		{
			try { return _repository.Create(thing, dealerIds.ToList()); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public HttpStatusCode CreateRange(IEnumerable<ProductPriceModel> Thing)
		{
			try { return _repository.CreateRange(Thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public HttpStatusCode DeleteOne(int id)
		{
			try { return _repository.Delete(id); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public HttpStatusCode DeleteRange(IEnumerable<int> id)
		{
			try { return _repository.DeleteRange(id); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public IEnumerable<ProductPriceModel> GetAll()
		{
			try { return _repository.GetAll(); } catch (Exception e) { Console.WriteLine(e); throw; }
		}

		public ProductPriceModel GetById(int id)
		{
			try { return _repository.GetById(id); } catch (Exception e) { Console.WriteLine(e); throw; }
		}

		public HttpStatusCode UpdateOne(ProductPriceModel thing, IEnumerable<int> dealerIds)
		{
			try { return _repository.Update(thing, dealerIds.ToList()); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}

		public HttpStatusCode UpdateRange(IEnumerable<ProductPriceModel> Thing)
		{
			try { return _repository.UpdateRange(Thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
		}
	}
}
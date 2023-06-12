using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
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
    }

    public HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing)
    {
        throw new NotImplementedException();
    }
}
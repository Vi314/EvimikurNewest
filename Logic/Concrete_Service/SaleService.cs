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

    public HttpStatusCode Create(SaleModel sale)
    {
        try
        {
            var result = _repository.Create(sale);
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
        return _repository.CreateRange(Thing);
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
        return _repository.DeleteRange(id);
    }

    public IEnumerable<SaleModel> GetAll()
    {
        return _repository.GetAll();
    }

    public SaleModel GetById(int id)
    {
        return _repository.GetById(id);
    }

    public HttpStatusCode Update(SaleModel sale)
    {
        return _repository.Update(sale);
    }

    public HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing)
    {
        return _repository.UpdateRange(Thing);
    }
}
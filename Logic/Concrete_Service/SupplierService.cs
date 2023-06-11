using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierService(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode CreateOne(SupplierModel supplier)
    {
        try
        {
            var result = _repository.Create(supplier);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(SupplierModel supplier)
    {
        try
        {
            var result = _repository.Update(supplier);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteSupplier(int id)
    {
        try
        {
            var result = _repository.Delete(id);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public IEnumerable<SupplierModel> GetSuppliers()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public SupplierModel GetById(int id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public HttpStatusCode CreateRange(IEnumerable<SupplierModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode UpdateRange(IEnumerable<SupplierModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        throw new NotImplementedException();
    }
}
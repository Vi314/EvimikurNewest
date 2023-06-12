using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class SupplierContractService : ISupplierContractService
{
    private readonly ISupplierContractRepository _repository;

    public SupplierContractService(ISupplierContractRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode CreateOne(SupplierContractModel supplierContract)
    {
        try
        {
            var result = _repository.Create(supplierContract);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(SupplierContractModel supplierContract)
    {
        try
        {
            var result = _repository.Update(supplierContract);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteSupplierContract(int id)
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

    public IEnumerable<SupplierContractModel> GetSupplierContracts()
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

    public SupplierContractModel GetById(int id)
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

    public HttpStatusCode CreateRange(IEnumerable<SupplierContractModel> Thing)
    {
        return _repository.CreateRange(Thing);
    }

    public HttpStatusCode UpdateRange(IEnumerable<SupplierContractModel> Thing)
    {
        return _repository.UpdateRange(Thing);
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        return _repository.DeleteRange(id);
    }

    public IEnumerable<SupplierContractModel> GetSupplierContractsByUser(int userId)
    {
        return _repository.GetAll(userId);
    }
}
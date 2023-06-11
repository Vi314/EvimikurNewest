using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class EmployeeInsuranceActionService : IEmployeeInsuranceActionService
{
    private readonly IEmployeeInsuranceActionRepository _repository;

    public EmployeeInsuranceActionService(IEmployeeInsuranceActionRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode CreateOne(EmployeeInsuranceActionModel insuranceAction)
    {
        try
        {
            return _repository.Create(insuranceAction);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(EmployeeInsuranceActionModel insuranceAction)
    {
        try
        {
            return _repository.Update(insuranceAction);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteEmployeeInsuranceAction(int id)
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

    public IEnumerable<EmployeeInsuranceActionModel> GetEmployeeInsuranceActions()
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

    public EmployeeInsuranceActionModel GetById(int id)
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

    public HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceActionModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceActionModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        throw new NotImplementedException();
    }
}
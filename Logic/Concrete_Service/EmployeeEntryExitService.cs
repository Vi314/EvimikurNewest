using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class EmployeeEntryExitService : IEmployeeEntryExitService
{
    private readonly IEmployeeEntryExitRepository _repository;

    public EmployeeEntryExitService(IEmployeeEntryExitRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode Create(EmployeeEntryExitModel employeeEntryExit)
    {
        try
        {
            return _repository.Create(employeeEntryExit);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode Update(EmployeeEntryExitModel employeeEntryExit)
    {
        try
        {
            return _repository.Update(employeeEntryExit);
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

    public IEnumerable<EmployeeEntryExitModel> GetAll()
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

    public EmployeeEntryExitModel GetById(int id)
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

    public HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExitModel> Thing)
    {
        return _repository.CreateRange(Thing);
    }

    public HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExitModel> Thing)
    {
        return _repository.UpdateRange(Thing);
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        return _repository.DeleteRange(id);
    }

    public IEnumerable<EmployeeEntryExitModel> GetByIds(IEnumerable<int> id)
    {
        throw new NotImplementedException();
    }

    public int ExecuteRawSql(string command)
    {
        throw new NotImplementedException();
    }
}
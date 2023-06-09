﻿using Entity.Entity;
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

    public HttpStatusCode Create(EmployeeInsuranceActionModel insuranceAction)
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

    public HttpStatusCode Update(EmployeeInsuranceActionModel insuranceAction)
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

    public IEnumerable<EmployeeInsuranceActionModel> GetAll()
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
        return _repository.CreateRange(Thing);
    }

    public HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceActionModel> Thing)
    {
        return _repository.UpdateRange(Thing);
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        return _repository.DeleteRange(id);
    }
}
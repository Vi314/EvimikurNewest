﻿using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode CreateOne(EmployeeModel employee)
    {
        try
        {
            return _repository.Create(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(EmployeeModel employee)
    {
        try
        {
            return _repository.Update(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteEmployee(int id)
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

    public IEnumerable<EmployeeModel> GetEmployees()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public EmployeeModel GetById(int id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public HttpStatusCode CreateRange(IEnumerable<EmployeeModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode UpdateRange(IEnumerable<EmployeeModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        throw new NotImplementedException();
    }
}
﻿using Entity.ConnectionEntity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class SalesAndProductsService : ISalesAndProductsService
{
    private readonly ISalesAndProductsRepository _repository;

    public SalesAndProductsService(ISalesAndProductsRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode Create(SalesAndProductsModel salesAndProducts)
    {
        try
        {
            return _repository.Create(salesAndProducts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode CreateRange(IEnumerable<SalesAndProductsModel> Thing)
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

    public IEnumerable<SalesAndProductsModel> GetAll()
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

    public IEnumerable<SalesAndProductsModel> GetAll(int id)
    {
        return _repository.GetAll().Where(x => x.Id == id);
    }

    public SalesAndProductsModel GetById(int id)
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

    public HttpStatusCode Update(SalesAndProductsModel salesAndProducts)
    {
        try
        {
            return _repository.Update(salesAndProducts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public HttpStatusCode UpdateRange(IEnumerable<SalesAndProductsModel> Thing)
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
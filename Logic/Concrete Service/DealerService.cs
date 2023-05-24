﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class DealerService : IDealerService
{
    private readonly IDealerRepository _repository;

    public DealerService(IDealerRepository repository)
    {
        _repository = repository;
    }
    public HttpStatusCode CreateOne(Dealer dealer)
    {
        try
        {
            return _repository.Create(dealer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(Dealer dealer)
    {
        try
        {
            return _repository.Update(dealer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteDealer(int id)
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

    public IEnumerable<Dealer> GetDealers()
    {
        return _repository.GetAll();
    }
    public Dealer GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<Dealer> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<Dealer> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

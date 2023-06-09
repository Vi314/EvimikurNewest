﻿using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class DealerService : IDealerService
{
	private readonly IDealerRepository _repository;

	public DealerService(IDealerRepository repository)
	{
		_repository = repository;
	}

	public HttpStatusCode Create(DealerModel dealer)
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

	public HttpStatusCode Update(DealerModel dealer)
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

	public IEnumerable<DealerModel> GetAll()
	{
		return _repository.GetAll();
	}

	public DealerModel GetById(int id)
	{
		try
		{
			return _repository.GetById(id);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw new Exception();
		}
	}

	public HttpStatusCode CreateRange(IEnumerable<DealerModel> Thing)
	{
        return _repository.CreateRange(Thing);
    }

    public HttpStatusCode UpdateRange(IEnumerable<DealerModel> Thing)
	{
		return _repository.UpdateRange(Thing);
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		return _repository.DeleteRange(id);
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class EmployeeEntryExitService : IEmployeeEntryExitService
{
	private readonly IEmployeeEntryExitRepository _repository;

	public EmployeeEntryExitService(IEmployeeEntryExitRepository repository)
	{
		_repository = repository;
	}
	public HttpStatusCode CreateOne(EmployeeEntryExit employeeEntryExit)
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

	public HttpStatusCode UpdateOne(EmployeeEntryExit employeeEntryExit)
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

	public HttpStatusCode DeleteEmployeeEntryExit(int id)
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

	public IEnumerable<EmployeeEntryExit> GetEmployeeEntryExit()
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

	public EmployeeEntryExit GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<EmployeeEntryExit> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<EmployeeEntryExit> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

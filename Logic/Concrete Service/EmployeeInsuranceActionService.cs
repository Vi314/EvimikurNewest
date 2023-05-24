using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class EmployeeInsuranceActionService : IEmployeeInsuranceActionService
{
	private readonly IEmployeeInsuranceActionRepository _repository;

	public EmployeeInsuranceActionService(IEmployeeInsuranceActionRepository repository)
	{
		_repository = repository;
	}
	public HttpStatusCode CreateOne(EmployeeInsuranceAction insuranceAction)
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

	public HttpStatusCode UpdateOne(EmployeeInsuranceAction insuranceAction)
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

	public IEnumerable<EmployeeInsuranceAction> GetEmployeeInsuranceActions()
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

	public EmployeeInsuranceAction GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<EmployeeInsuranceAction> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<EmployeeInsuranceAction> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

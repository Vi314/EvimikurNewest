using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	public HttpStatusCode CreateOne(SupplierContract supplierContract)
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

	public HttpStatusCode UpdateOne(SupplierContract supplierContract)
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

	public IEnumerable<SupplierContract> GetSupplierContracts()
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

	public SupplierContract GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<SupplierContract> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<SupplierContract> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

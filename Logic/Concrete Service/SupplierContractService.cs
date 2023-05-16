using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Repository;

namespace Logic.Concrete_Service
{
	public class SupplierContractService:ISupplierContractService
	{
		private readonly IRepository<SupplierContract> _repository;

		public SupplierContractService(IRepository<SupplierContract> repository)
		{
			_repository = repository;
		}
		public string CreateOne(SupplierContract supplierContract)
		{
			try
			{
				var result = _repository.Create(supplierContract);
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string UpdateOne(SupplierContract supplierContract)
		{
			try
			{
				var result = _repository.Update(supplierContract);
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string DeleteSupplierContract(int id)
		{
			try
			{
				var result = _repository.Delete(id);
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
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
	}
}

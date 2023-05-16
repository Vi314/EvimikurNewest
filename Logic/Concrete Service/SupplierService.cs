using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Repository;

namespace Logic.Concrete_Service
{
	public class SupplierService:ISupplierService
	{
		private readonly IRepository<Supplier> _repository;

		public SupplierService(IRepository<Supplier> repository)
		{
			_repository = repository;
		}
		public string CreateOne(Supplier supplier)
		{
			try
			{
				var result= _repository.Create(supplier);
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string UpdateOne(Supplier supplier)
		{
			try
			{
				var result = _repository.Update(supplier);
				return result;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string DeleteSupplier(int id)
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

		public IEnumerable<Supplier> GetSuppliers()
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

		public Supplier GetById(int id)
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

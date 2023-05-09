using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service
{
	public class SalesService : ISalesService
	{
		private readonly IRepository<Sale> _repository;

		public SalesService(IRepository<Sale> repository)
		{
			_repository = repository;
		}
		public string CreateSale(Sale sale)
		{
			try
			{
				return _repository.Create(sale);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string DeleteSale(int id)
		{
			try
			{
				return _repository.Delete(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public IEnumerable<Sale> GetAll()
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

		public Sale GetById(int id)
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

		public string UpdateSale(Sale sale)
		{
			try
			{
				return _repository.Update(sale);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
				throw;
			}
		}
	}
}

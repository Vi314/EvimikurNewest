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
	public class EmployeeInsuranceActionService:IEmployeeInsuranceActionService
	{
		private readonly IRepository<EmployeeInsuranceAction> _repository;

		public EmployeeInsuranceActionService(IRepository<EmployeeInsuranceAction> repository)
		{
			_repository = repository;
		}
		public string CreateOne(EmployeeInsuranceAction insuranceAction)
		{
			try
			{
				return _repository.Create(insuranceAction);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string UpdateOne(EmployeeInsuranceAction insuranceAction)
		{
			try
			{
				return _repository.Update(insuranceAction);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string DeleteEmployeeInsuranceAction(int id)
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
	}
}

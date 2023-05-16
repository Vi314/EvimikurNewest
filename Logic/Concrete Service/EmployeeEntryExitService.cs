using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Service;
using Logic.Repository;

namespace Logic.Concrete_Service
{
	public class EmployeeEntryExitService:IEmployeeEntryExitService
	{
		private readonly IRepository<EmployeeEntryExit> _repository;

		public EmployeeEntryExitService(IRepository<EmployeeEntryExit> repository)
		{
			_repository = repository;
		}
		public string CreateOne(EmployeeEntryExit employeeEntryExit)
		{
			try
			{
				return _repository.Create(employeeEntryExit);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string UpdateOne(EmployeeEntryExit employeeEntryExit)
		{
			try
			{
				return _repository.Update(employeeEntryExit);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.Message;
			}
		}

		public string DeleteEmployeeEntryExit(int id)
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
		
	}
}

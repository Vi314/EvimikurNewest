using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class EmployeeVacationService : IEmployeeVacationService
{
    private readonly IEmployeeVacationRepository _repository;

    public EmployeeVacationService(IEmployeeVacationRepository repository)
    {
        _repository = repository;
    }
	public HttpStatusCode CreateOne(EmployeeVacationModel employeeVacation)
    {
        try
        {
            return _repository.Create(employeeVacation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(EmployeeVacationModel employeeVacation)
    {
        try
        {
            return _repository.Update(employeeVacation);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteEmployeeVacation(int id)
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

    public IEnumerable<EmployeeVacationModel> GetEmployeeVacation()
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

    public EmployeeVacationModel GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<EmployeeVacationModel> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<EmployeeVacationModel> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

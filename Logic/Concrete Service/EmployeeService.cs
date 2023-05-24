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

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    
    public HttpStatusCode CreateOne(Employee employee)
    {
        try
        {
            return _repository.Create(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(Employee employee)
    {
        try
        {
            return _repository.Update(employee);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteEmployee(int id)
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

    public IEnumerable<Employee> GetEmployees()
    {
        try
        {
            return _repository.GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    public Employee GetById(int id)
    {
	        try
	        {
		        return _repository.GetById(id);

	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
		        return null;
	        }
    }

	public HttpStatusCode CreateRange(IEnumerable<Employee> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<Employee> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

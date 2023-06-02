using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }
    public HttpStatusCode CreateOne(OrderModel order)
    {
        try
        {
            return _repository.Create(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(OrderModel order)
    {
        try
        {
            return _repository.Update(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteOrder(int id)
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

    public IEnumerable<OrderModel> GetOrders()
    {
	        return _repository.GetAll();
    }
    public OrderModel GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<OrderModel> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<OrderModel> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

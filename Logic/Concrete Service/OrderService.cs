using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class OrderService:IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }
    public string CreateOne(Order order)
    {
        try
        {
            return _repository.Create(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string UpdateOne(Order order)
    {
        try
        {
            return _repository.Update(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string DeleteOrder(int id)
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

    public IEnumerable<Order> GetOrders()
    {
	        return _repository.GetAll();
    }
    public Order GetById(int id)
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
}

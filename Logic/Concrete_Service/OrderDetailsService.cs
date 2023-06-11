using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly IOrderDetailsRepository _repository;

    public OrderDetailsService(IOrderDetailsRepository repository)
    {
        _repository = repository;
    }

    public HttpStatusCode CreateOne(OrderDetailsModel orderDetails)
    {
        try
        {
            return _repository.Create(orderDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(OrderDetailsModel orderDetails)
    {
        try
        {
            return _repository.Update(orderDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteOrderDetails(int id)
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

    public IEnumerable<OrderDetailsModel> GetOrderDetails()
    {
        return _repository.GetAll();
    }

    public OrderDetailsModel GetById(int id)
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

    public HttpStatusCode CreateRange(IEnumerable<OrderDetailsModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode UpdateRange(IEnumerable<OrderDetailsModel> Thing)
    {
        throw new NotImplementedException();
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        throw new NotImplementedException();
    }
}
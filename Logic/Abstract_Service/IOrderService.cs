using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IOrderService
    {
        HttpStatusCode CreateRange(IEnumerable<OrderModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<OrderModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(OrderModel order);

        HttpStatusCode UpdateOne(OrderModel order);

        HttpStatusCode DeleteOrder(int id);

        IEnumerable<OrderModel> GetOrders();

        OrderModel GetById(int id);
    }
}
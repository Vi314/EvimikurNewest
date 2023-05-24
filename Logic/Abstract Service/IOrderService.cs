using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IOrderService
    {
		HttpStatusCode CreateRange(IEnumerable<Order> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Order> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(Order order);
        HttpStatusCode UpdateOne(Order order);
        HttpStatusCode DeleteOrder(int id);
        IEnumerable<Order> GetOrders();
        Order GetById(int id);

}
}
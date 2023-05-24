using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IOrderDetailsService
    {
		HttpStatusCode CreateRange(IEnumerable<OrderDetails> Thing);
		HttpStatusCode UpdateRange(IEnumerable<OrderDetails> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);

		HttpStatusCode CreateOne(OrderDetails orderDetails);
        HttpStatusCode UpdateOne(OrderDetails orderDetails);
        HttpStatusCode DeleteOrderDetails(int id);
        IEnumerable<OrderDetails> GetOrderDetails();
        OrderDetails GetById(int id);

}
}
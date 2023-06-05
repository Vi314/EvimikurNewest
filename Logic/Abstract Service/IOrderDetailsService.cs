using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IOrderDetailsService
    {
        HttpStatusCode CreateRange(IEnumerable<OrderDetailsModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<OrderDetailsModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        HttpStatusCode CreateOne(OrderDetailsModel orderDetails);

        HttpStatusCode UpdateOne(OrderDetailsModel orderDetails);

        HttpStatusCode DeleteOrderDetails(int id);

        IEnumerable<OrderDetailsModel> GetOrderDetails();

        OrderDetailsModel GetById(int id);
    }
}
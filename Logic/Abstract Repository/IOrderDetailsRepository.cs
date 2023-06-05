using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IOrderDetailsRepository
    {
        HttpStatusCode Create(OrderDetailsModel orderDetails);

        HttpStatusCode Update(OrderDetailsModel orderDetails);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<OrderDetailsModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<OrderDetailsModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        OrderDetailsModel GetById(int id);

        IEnumerable<OrderDetailsModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
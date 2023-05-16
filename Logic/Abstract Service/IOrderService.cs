using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IOrderService
    {
        string CreateOne(Order order);
        string UpdateOne(Order order);
        string DeleteOrder(int id);
        IEnumerable<Order> GetOrders();
        Order GetById(int id);

}
}
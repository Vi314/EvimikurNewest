using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IOrderService
    {
        string CreateOrder(Order order);
        string UpdateOrder(Order order);
        string DeleteOrder(int id);
        IEnumerable<Order> GetOrders();
        Order GetById(int id);

}
}
using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IOrderDetailsService
    {
        string CreateOrderDetails(OrderDetails orderDetails);
        string UpdateOrderDetails(OrderDetails orderDetails);
        string DeleteOrderDetails(int id);
        IEnumerable<OrderDetails> GetOrderDetails();
        OrderDetails GetById(int id);

}
}
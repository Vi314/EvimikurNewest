using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IOrderDetailsService
    {
        string CreateOne(OrderDetails orderDetails);
        string UpdateOne(OrderDetails orderDetails);
        string DeleteOrderDetails(int id);
        IEnumerable<OrderDetails> GetOrderDetails();
        OrderDetails GetById(int id);

}
}
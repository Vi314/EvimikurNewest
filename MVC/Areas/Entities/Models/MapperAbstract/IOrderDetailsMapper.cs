using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IOrderDetailsMapper
    {
        public OrderDetailsDTO FromOrderDetails(OrderDetails orderDetails, IEnumerable<Product> products);
        public OrderDetails ToOrderDetails(OrderDetailsDTO orderDetailsDTO, IEnumerable<Product> products);

    }
}

using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IOrderDetailsMapper
    {
        public OrderDetailsDTO FromEntity(OrderDetails orderDetails);
        public OrderDetails FromDto(OrderDetailsDTO orderDetailsDTO);

    }
}

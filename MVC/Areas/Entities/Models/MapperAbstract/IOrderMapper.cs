using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IOrderMapper
    {
        public OrderDTO FromEntity(Order order);
        public Order FromDto(OrderDTO orderDTO);
    }
}

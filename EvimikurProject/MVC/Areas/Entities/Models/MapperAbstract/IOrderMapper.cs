using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IOrderMapper
    {
        public OrderDTO FromOrder(Order order, IEnumerable<Employee> employees, IEnumerable<Dealer> dealers, IEnumerable<Supplier> suppliers);
        public Order ToOrder(OrderDTO orderDTO, IEnumerable<Employee> employees, IEnumerable<Dealer> dealers, IEnumerable<Supplier> suppliers);
    }
}

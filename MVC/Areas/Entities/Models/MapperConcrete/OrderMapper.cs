using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDTO FromOrder(Order order, IEnumerable<Employee> employees, IEnumerable<Dealer> dealers,IEnumerable<Supplier> suppliers)
        {
            var orderDTO = new OrderDTO
            {
                Id= order.Id,
                Price= order.Price,
                OrderDate= order.OrderDate,
                OrderType= order.OrderType,
                DealerName = dealers.Where(x => x.Id == order.DealerId).Select(x => x.Name).FirstOrDefault(),
                EmployeeName = employees.Where(x => x.Id == order.EmployeeId).Select(x => $"{x.FirstName} {x.LastName}").FirstOrDefault(),
                
            };

            if (order.SupplierId != null)
            {
                orderDTO.SupplierName = suppliers.Where(x => x.Id == order.SupplierId).Select(x => x.CompanyName).FirstOrDefault();
            }

            return orderDTO;
        }

        public Order ToOrder(OrderDTO orderDTO, IEnumerable<Employee> employees, IEnumerable<Dealer> dealers, IEnumerable<Supplier> suppliers)
        {
            var order = new Order
            {
                Id= orderDTO.Id,
                OrderDate= orderDTO.OrderDate,
                OrderType= orderDTO.OrderType,
                DealerId = dealers.Where(x => x.Name == orderDTO.DealerName).Select(x => x.Id).FirstOrDefault(),
                EmployeeId = employees.Where(x=> $"{x.FirstName} {x.LastName}" == orderDTO.EmployeeName).Select(x => x.Id).FirstOrDefault(),
                Price= orderDTO.Price,
            };
            if (orderDTO.SupplierName != null)
            {
                order.SupplierId = suppliers.Where(x => x.CompanyName == orderDTO.SupplierName).Select(x => x.Id).FirstOrDefault();
            }
            return order;
        }
    }
}

using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDTO FromEntity(OrderModel order)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                TotalPrice = order.Price,
                OrderDate = order.OrderDate,
                OrderType = order.OrderType,
                DealerName = order.Dealer.Name,
                EmployeeName = order.Employee.FirstName + " " + order.Employee.LastName,
                SupplierName = order.Supplier.CompanyName,
                DealerId = order.DealerId,
                SupplierId = order.SupplierId,
                EmployeeId = order.EmployeeId,
            };
#pragma warning restore CS8601 // Possible null reference assignment.

            return orderDTO;
        }

        public OrderModel FromDto(OrderDTO orderDTO)
        {
            var order = new OrderModel
            {
                Id = orderDTO.Id,
                OrderDate = orderDTO.OrderDate,
                OrderType = orderDTO.OrderType,
                Price = orderDTO.TotalPrice,
                DealerId = orderDTO.DealerId,
                SupplierId = orderDTO.SupplierId,
                EmployeeId = orderDTO.EmployeeId,
            };
            return order;
        }
    }
}
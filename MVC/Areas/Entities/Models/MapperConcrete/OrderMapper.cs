using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDto FromEntity(OrderModel order)
        {
            var orderDTO = new OrderDto
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

            return orderDTO;
        }

        public OrderModel FromDto(OrderDto orderDTO)
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

        public IEnumerable<OrderDto> FromEntityRange(IEnumerable<OrderModel> entities)
        {
            foreach (var entity in entities)
            {
                yield return FromEntity(entity);
            }
        }

        public IEnumerable<OrderModel> FromDtoRange(IEnumerable<OrderDto> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return FromDto(dto);
            }      
        }
    }
}
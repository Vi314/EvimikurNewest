using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class OrderDetailsMapper : IOrderDetailsMapper
    {
        public OrderDetailsDTO FromEntity(OrderDetailsModel orderDetails)
        {
            var orderDetailsDTO = new OrderDetailsDTO
            {
                Id= orderDetails.Id,
                Amount = orderDetails.Amount,
                OrderId = orderDetails.OrderId, 
                Price = orderDetails.Price,
                ProductName = orderDetails.Product.ProductName,
                ProductId = orderDetails.ProductId,
            };
            return orderDetailsDTO;
        }

        public OrderDetailsModel FromDto(OrderDetailsDTO orderDetailsDTO)
        {
            var orderDetails = new OrderDetailsModel
            {
                Id= orderDetailsDTO.Id,
                Amount = orderDetailsDTO.Amount,
                OrderId = orderDetailsDTO.OrderId,
                Price = orderDetailsDTO.Price,
                ProductId = orderDetailsDTO.ProductId,
            };
            return orderDetails;
        }
    }
}

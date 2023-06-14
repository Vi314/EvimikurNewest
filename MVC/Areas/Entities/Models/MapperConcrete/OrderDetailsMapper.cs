using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete;

public class OrderDetailsMapper : IOrderDetailsMapper
{
    public OrderDetailsDto FromEntity(OrderDetailsModel orderDetails)
    {
        var orderDetailsDTO = new OrderDetailsDto
        {
            Id = orderDetails.Id,
            Amount = orderDetails.Amount,
            OrderId = orderDetails.OrderId,
            Price = orderDetails.Price,
            ProductName = orderDetails.Product.ProductName,
            ProductId = orderDetails.ProductId,
        };
        return orderDetailsDTO;
    }

    public OrderDetailsModel FromDto(OrderDetailsDto orderDetailsDTO)
    {
        var orderDetails = new OrderDetailsModel
        {
            Id = orderDetailsDTO.Id,
            Amount = orderDetailsDTO.Amount,
            OrderId = orderDetailsDTO.OrderId,
            Price = orderDetailsDTO.Price,
            ProductId = orderDetailsDTO.ProductId,
        };
        return orderDetails;
    }

    public IEnumerable<OrderDetailsDto> FromEntityRange(IEnumerable<OrderDetailsModel> entities)
    {
        foreach (var entity in entities)
        {
            yield return FromEntity(entity);
        }
    }
            
    public IEnumerable<OrderDetailsModel> FromDtoRange(IEnumerable<OrderDetailsDto> dtos)
    {
        foreach (var dto in dtos)
        {
            yield return FromDto(dto);
        }
    }
}
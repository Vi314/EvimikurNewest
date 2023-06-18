using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete;

public class SaleMapper : ISaleMapper
{
    public SaleDto FromEntity(SaleModel sale)
    {
        var saleDto = new SaleDto
        {
            Description = sale.Description,
            Discount = sale.Discount,
            StartDate = sale.StartDate,
            EndDate = sale.EndDate,
            Id = sale.Id,
            IsForAllDealers = sale.IsForAllDealers,
            IsForAllProducts = sale.IsForAllProducts,
            Dealerids = sale.Dealers.Select(d => d.Id).ToList(),
            Productids = sale.Products.Select(p => p.Id).ToList(),
        };

        return saleDto;
    }

    public SaleModel FromDto(SaleDto saleDto)
    {
        var sale = new SaleModel
        {
            Discount = saleDto.Discount,
            Description = saleDto.Description == null ? "" : saleDto.Description.Trim(),
            StartDate = Convert.ToDateTime(saleDto.StartDate),
            EndDate = Convert.ToDateTime(saleDto.EndDate),
            Id = saleDto.Id,
            IsForAllDealers = saleDto.IsForAllDealers,
            IsForAllProducts = saleDto.IsForAllProducts,
            Dealers  = saleDto.Dealerids.Select(x => new DealerModel { Id = x }).ToList(),
            Products = saleDto.Productids.Select(x => new ProductModel { Id = x }).ToList(),
        };

        return sale;
    }

    public IEnumerable<SaleDto> FromEntityRange(IEnumerable<SaleModel> entities)
    {
        foreach (var entity in entities)
        {
            yield return FromEntity(entity);
        }
    }

    public IEnumerable<SaleModel> FromDtoRange(IEnumerable<SaleDto> dtos)
    {
        foreach(var dto in dtos)
        {
            yield return FromDto(dto);
        }
    }
}
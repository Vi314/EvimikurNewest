using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class ProductPriceMapper : IProductPriceMapper
    {
        public ProductPriceModel FromDto(ProductPriceDto dto)
        {
            var model = new ProductPriceModel
            {
                Id = dto.Id,
                SellingPrice = dto.SellingPrice,
                Description = dto.Description,
                TaxPercentage = dto.TaxPercentage,
                TaxPrice = dto.TaxPrice,
                DiscountPercentage = dto.DiscountPercentage,
                DiscountedPrice = dto.DiscountedPrice,
                ProductionPrice = dto.ProductionPrice,
                ProductId = dto.ProductId,
                ValidUntil = dto.ValidUntil,
            };

            return model;
        }

        public ProductPriceDto FromEntity(ProductPriceModel model)
        {
            var dto = new ProductPriceDto
            {
                Id = model.Id,
                ProductId = model.ProductId,
                ProductName = model.Product.ProductName ?? "",
                ProductionPrice = model.ProductionPrice,
                Description = model.Description,
                DiscountedPrice = model.DiscountedPrice,
                DiscountPercentage = model.DiscountPercentage,
                SellingPrice = model.SellingPrice,
                TaxPercentage = model.TaxPercentage,
                TaxPrice = model.TaxPrice,
                ValidUntil = model.ValidUntil,
            };

            return dto;
        }
    }
}
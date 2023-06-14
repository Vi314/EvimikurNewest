using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete;

public class ProductMapper : IProductMapper
{
    public ProductDto FromEntity(ProductModel product)
    {
        ProductDto productDTO = new ProductDto
        {
            Id = product.Id,
            Name = product.ProductName,
            Description = product.Description,
            FunctionalityGrade = product.FunctionalityGrade,
            PotentialSalesGrade = product.PotentialSalesGrade,
            PriceAdvantageGrade = product.PriceAdvantageGrade,
            InnovativeGrade = product.InnovativeGrade,
            LooksGrade = product.LooksGrade,
            UsabilityGrade = product.UsabilityGrade,
            Category = product.Category.Name,
            CategoryId = product.CategoryId,
        };

        return productDTO;
    }

    public ProductModel FromDto(ProductDto productDTO)
    {
        ProductModel product = new ProductModel
        {
            Id = productDTO.Id,
            ProductName = productDTO.Name.Trim(),
            Description = productDTO.Description.Trim(),
            PotentialSalesGrade = productDTO.PotentialSalesGrade,
            FunctionalityGrade = productDTO.FunctionalityGrade,
            LooksGrade = productDTO.LooksGrade,
            InnovativeGrade = productDTO.InnovativeGrade,
            PriceAdvantageGrade = productDTO.PriceAdvantageGrade,
            UsabilityGrade = productDTO.UsabilityGrade,
            CategoryId = productDTO.CategoryId,
        };

        return product;
    }

    public IEnumerable<ProductDto> FromEntityRange(IEnumerable<ProductModel> entities)
    {
        foreach (var entity in entities)
        {
            yield return FromEntity(entity);
        }
    }

    public IEnumerable<ProductModel> FromDtoRange(IEnumerable<ProductDto> dtos)
    {
        foreach (var dto in dtos)
        {
            yield return FromDto(dto);
        }
    }
}
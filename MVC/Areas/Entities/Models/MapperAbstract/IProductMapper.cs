using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IProductMapper
    {
        public ProductModel FromDto(ProductDTO productDTO);

        public ProductDTO FromEntity(ProductModel product);
    }
}
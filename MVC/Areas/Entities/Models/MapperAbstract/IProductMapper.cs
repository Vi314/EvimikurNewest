using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstractGeneric;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IProductMapper:IBaseMapper<ProductDto, ProductModel>
    {
    }
}
using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IProductPriceMapper
	{
		public ProductPriceModel FromDto(ProductPriceDto dto);
		public ProductPriceDto FromEntity(ProductPriceModel model);
	}
}

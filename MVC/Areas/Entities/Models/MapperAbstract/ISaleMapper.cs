using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface ISaleMapper
	{
		public SaleDTO FromEntity(SaleModel sale);
		public SaleModel FromDto(SaleDTO saleDto);

	}
}

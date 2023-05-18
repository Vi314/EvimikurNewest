using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface ISaleMapper
	{
		public SaleDTO FromSale(Sale sale);
		public Sale ToSale(SaleDTO saleDto);

	}
}

using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IDealerStocksMapper
	{
		public DealerStocks FromDto(DealerStockDTO dealerStocksDTO);
		public DealerStockDTO FromEntity(DealerStocks dealerStocks);
	}
}

using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IDealerStocksMapper
	{
		public DealerStocks ToDealerStock(DealerStockDTO dealerStocksDTO);
		public DealerStockDTO FromDealerStock(DealerStocks dealerStocks);
	}
}

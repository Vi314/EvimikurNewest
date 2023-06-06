using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IDealerStocksMapper
    {
        public DealerStocksModel FromDto(DealerStockDTO dealerStocksDTO);

        public DealerStockDTO FromEntity(DealerStocksModel dealerStocks);
    }
}
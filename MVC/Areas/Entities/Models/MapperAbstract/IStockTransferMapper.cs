using Entity.Entity;
using Entity.Non_Db_Objcets;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IStockTransferMapper
    {
        public StockTransferObject ToStockTransferObject(StockTransferDTO stockTransferDTO, IEnumerable<ProductModel> products, IEnumerable<DealerModel> dealers);

        public StockTransferDTO FromStockTransferObject(StockTransferObject transferObject, IEnumerable<ProductModel> products, IEnumerable<DealerModel> dealers);
    }
}
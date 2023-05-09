using Entity.Entity;
using Entity.Non_Db_Objcets;

namespace Logic.Abstract_Service
{
    public interface IDealerStocksService
    {
        string CreateDealerStocks(DealerStocks dealerStocks);
        string UpdateDealerStocks(DealerStocks dealerStocks);
        string DeleteDealerStocks(int id);
        IEnumerable<DealerStocks> GetDealerStocks();
        DealerStocks GetById(int id);
        public string TransferStock(StockTransferObject transferObject);
}
}
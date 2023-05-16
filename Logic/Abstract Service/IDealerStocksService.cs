using Entity.Entity;
using Entity.Non_Db_Objcets;

namespace Logic.Abstract_Service
{
    public interface IDealerStocksService
    {
        string CreateOne(DealerStocks dealerStocks);
        string UpdateOne(DealerStocks dealerStocks);
        string DeleteDealerStocks(int id);
        IEnumerable<DealerStocks> GetDealerStocks();
        DealerStocks GetById(int id);
        public string TransferStock(StockTransferObject transferObject);
}
}
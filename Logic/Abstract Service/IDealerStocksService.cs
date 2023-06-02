using Entity.Entity;
using Entity.Non_Db_Objcets;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IDealerStocksService
    {
		HttpStatusCode CreateRange(IEnumerable<DealerStocksModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<DealerStocksModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		
        HttpStatusCode CreateOne(DealerStocksModel dealerStocks);
        HttpStatusCode UpdateOne(DealerStocksModel dealerStocks);
        HttpStatusCode DeleteDealerStocks(int id);
        IEnumerable<DealerStocksModel> GetDealerStocks();
        DealerStocksModel GetById(int id);
        public string TransferStock(StockTransferObject transferObject);
}
}
using Entity.Entity;
using Entity.Non_Db_Objcets;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IDealerStocksService
    {
		HttpStatusCode CreateRange(IEnumerable<DealerStocks> Thing);
		HttpStatusCode UpdateRange(IEnumerable<DealerStocks> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		
        HttpStatusCode CreateOne(DealerStocks dealerStocks);
        HttpStatusCode UpdateOne(DealerStocks dealerStocks);
        HttpStatusCode DeleteDealerStocks(int id);
        IEnumerable<DealerStocks> GetDealerStocks();
        DealerStocks GetById(int id);
        public string TransferStock(StockTransferObject transferObject);
}
}
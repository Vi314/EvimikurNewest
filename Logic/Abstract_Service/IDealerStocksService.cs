using Entity.Entity;
using Entity.Non_Db_Objcets;
using Logic.Abstract_Generic;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IDealerStocksService:IBaseService<DealerStocksModel>
    {
        public string TransferStock(StockTransferObject transferObject);
    }
}
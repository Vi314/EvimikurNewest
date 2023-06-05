using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface IDealerStocksRepository
    {
        HttpStatusCode Create(DealerStocksModel dealerStocks);

        HttpStatusCode Update(DealerStocksModel dealerStocks);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<DealerStocksModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<DealerStocksModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        DealerStocksModel GetById(int id);

        IEnumerable<DealerStocksModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
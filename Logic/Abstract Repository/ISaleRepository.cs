using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Repository
{
    public interface ISaleRepository
    {
        HttpStatusCode Create(SaleModel sale);

        HttpStatusCode Create(SaleModel sale, List<int> dealerids, List<int> productids);

        HttpStatusCode Update(SaleModel sale);

        HttpStatusCode Update(SaleModel sale, List<int> dealerids, List<int> productids);

        HttpStatusCode Delete(int id);

        HttpStatusCode CreateRange(IEnumerable<SaleModel> Thing);

        HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing);

        HttpStatusCode DeleteRange(IEnumerable<int> id);

        SaleModel GetById(int id);

        IEnumerable<SaleModel> GetAll();

        int ExecuteRawSql(string command);
    }
}
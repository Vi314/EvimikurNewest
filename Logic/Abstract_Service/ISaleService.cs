using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISaleService
{
    HttpStatusCode CreateRange(IEnumerable<SaleModel> Thing);

    HttpStatusCode UpdateRange(IEnumerable<SaleModel> Thing);

    HttpStatusCode DeleteRange(IEnumerable<int> id);

    HttpStatusCode CreateOne(SaleModel sale, List<int> dealerId, List<int> productId);

    HttpStatusCode UpdateOne(SaleModel sale, List<int> dealerId, List<int> productId);

    HttpStatusCode DeleteOne(int id);

    IEnumerable<SaleModel> GetAll();

    SaleModel GetById(int id);
}
using Entity.ConnectionEntity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISalesAndProductsService
{
    HttpStatusCode CreateRange(IEnumerable<SalesAndProductsModel> Thing);

    HttpStatusCode UpdateRange(IEnumerable<SalesAndProductsModel> Thing);

    HttpStatusCode DeleteRange(IEnumerable<int> id);

    IEnumerable<SalesAndProductsModel> GetAll();

    IEnumerable<SalesAndProductsModel> GetAll(int id);

    SalesAndProductsModel GetById(int id);

    HttpStatusCode Create(SalesAndProductsModel salesAndProducts);

    HttpStatusCode Update(SalesAndProductsModel salesAndProducts);

    HttpStatusCode Delete(int id);
}
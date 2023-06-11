using Entity.ConnectionEntity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISalesAndDealersService
{
    HttpStatusCode CreateRange(IEnumerable<SalesAndDealersModel> Thing);

    HttpStatusCode UpdateRange(IEnumerable<SalesAndDealersModel> Thing);

    HttpStatusCode DeleteRange(IEnumerable<int> id);

    IEnumerable<SalesAndDealersModel> GetAll();

    IEnumerable<SalesAndDealersModel> GetAll(int saleId);

    SalesAndDealersModel GetById(int id);

    HttpStatusCode Create(SalesAndDealersModel salesAndDealers);

    HttpStatusCode Update(SalesAndDealersModel salesAndDealers);

    HttpStatusCode Delete(int id);
}
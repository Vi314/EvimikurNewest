using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IDealerService
    {
		HttpStatusCode CreateRange(IEnumerable<DealerModel> Thing);
		HttpStatusCode UpdateRange(IEnumerable<DealerModel> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(DealerModel dealer);
        HttpStatusCode UpdateOne(DealerModel dealer);
        HttpStatusCode DeleteDealer(int id);
        IEnumerable<DealerModel> GetDealers();
        DealerModel GetById(int id);

}
}
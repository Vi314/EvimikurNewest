using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service
{
    public interface IDealerService
    {
		HttpStatusCode CreateRange(IEnumerable<Dealer> Thing);
		HttpStatusCode UpdateRange(IEnumerable<Dealer> Thing);
		HttpStatusCode DeleteRange(IEnumerable<int> id);
		HttpStatusCode CreateOne(Dealer dealer);
        HttpStatusCode UpdateOne(Dealer dealer);
        HttpStatusCode DeleteDealer(int id);
        IEnumerable<Dealer> GetDealers();
        Dealer GetById(int id);

}
}
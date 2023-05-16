using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IDealerService
    {
        string CreateOne(Dealer dealer);
        string UpdateOne(Dealer dealer);
        string DeleteDealer(int id);
        IEnumerable<Dealer> GetDealers();
        Dealer GetById(int id);

}
}
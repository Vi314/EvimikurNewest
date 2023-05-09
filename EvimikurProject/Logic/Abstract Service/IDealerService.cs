using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IDealerService
    {
        string CreateDealer(Dealer dealer);
        string UpdateDealer(Dealer dealer);
        string DeleteDealer(int id);
        IEnumerable<Dealer> GetDealers();
        Dealer GetById(int id);

}
}
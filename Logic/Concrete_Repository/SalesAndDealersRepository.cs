using DataAccess;
using Entity.ConnectionEntity;
using Logic.Abstract_Repository;

namespace Logic.Repository;

public class SalesAndDealersRepository : BaseRepository<SalesAndDealersModel>, ISalesAndDealersRepository
{
    private Context _context;

    public SalesAndDealersRepository(Context context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<SalesAndDealersModel> GetAll(int saleId)
    {
        var result = _context.SalesAndDealers.Where(x => x.SaleId == saleId).ToList();
        return result;
    }
}
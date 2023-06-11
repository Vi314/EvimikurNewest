using DataAccess;
using Entity.ConnectionEntity;
using Logic.Abstract_Repository;

namespace Logic.Concrete_Repository
{
    public class SalesAndProductsRepository : BaseRepository<SalesAndProductsModel>, ISalesAndProductsRepository
    {
        private readonly Context _context;

        public SalesAndProductsRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}
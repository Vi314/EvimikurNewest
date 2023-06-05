using DataAccess;
using Entity.ConnectionEntity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository;

public class ProductPriceAndDealersRepository : BaseRepository<ProductPriceAndDealersModel>, IProductPriceAndDealersRepository
{
    private readonly Context _context;

    public ProductPriceAndDealersRepository(Context context) : base(context)
    {
        _context = context;
    }

    public override IEnumerable<ProductPriceAndDealersModel> GetAll()
    {
        var priceAndDealers = from pad in _context.ProductPriceAndDealers
                              join p in _context.ProductPrices on pad.ProductPriceId equals p.Id
                              join d in _context.Dealers on pad.DealerId equals d.Id
                              where pad.State != EntityState.Deleted
                                && p.State != EntityState.Deleted
                                && d.State != EntityState.Deleted
                              select new ProductPriceAndDealersModel
                              {
                                  CreatedDate = pad.CreatedDate,
                                  Dealer = d ?? new(),
                                  DealerId = p.Id,
                                  Id = pad.Id,
                                  ProductPrice = p ?? new(),
                                  State = pad.State,
                                  ProductPriceId = pad.ProductPriceId,
                              };

        return priceAndDealers;
    }

    public override ProductPriceAndDealersModel GetById(int id)
    {
        var priceAndDealer = (from pad in _context.ProductPriceAndDealers
                              join p in _context.ProductPrices on pad.ProductPriceId equals p.Id
                              join d in _context.Dealers on pad.DealerId equals d.Id
                              where pad.Id == id
                                && pad.State != EntityState.Deleted
                                && p.State != EntityState.Deleted
                                && d.State != EntityState.Deleted
                              select new ProductPriceAndDealersModel
                              {
                                  CreatedDate = pad.CreatedDate,
                                  Dealer = d ?? new(),
                                  DealerId = p.Id,
                                  Id = pad.Id,
                                  ProductPrice = p ?? new(),
                                  State = pad.State,
                                  ProductPriceId = pad.ProductPriceId,
                              }).FirstOrDefault();

        return priceAndDealer ?? new();
    }
}
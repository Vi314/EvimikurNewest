using DataAccess;
using Entity.ConnectionEntity;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Logic.Concrete_Repository
{
    public class ProductPriceRepository : BaseRepository<ProductPriceModel>, IProductPriceRepository
    {
        private readonly DataAccess.Context _context;
		private readonly IEntityConnectionManager<ProductPriceAndDealersModel> _dealerConnection;

		public ProductPriceRepository(DataAccess.Context context, IEntityConnectionManager<ProductPriceAndDealersModel> dealerConnection) : base(context)
        {
            _context = context;

			dealerConnection.ConnectionPropertyName = nameof(ProductPriceAndDealersModel.DealerId);
            dealerConnection.MainPropertyName = nameof(ProductPriceAndDealersModel.ProductPriceId);
			_dealerConnection = dealerConnection;
		}

		public override IEnumerable<ProductPriceModel> GetAll()
        {
            var prices = from pp in _context.ProductPrices
                         join p in _context.Products on pp.ProductId equals p.Id
                         where pp.State != EntityState.Deleted
                            && p.State != EntityState.Deleted
                         select new ProductPriceModel
                         {
                             CreatedDate = pp.CreatedDate,
                             State = pp.State,
                             SellingPrice = pp.SellingPrice,
                             Id = pp.Id,
                             Product = p ?? new(),
                             ProductId = pp.ProductId,
                             ProductionPrice = pp.ProductionPrice,
                             TaxPrice = pp.TaxPrice,
                             ValidUntil = pp.ValidUntil,
                             Description = pp.Description,
                             DiscountedPrice = pp.DiscountedPrice,
                             DiscountPercentage = pp.DiscountPercentage,
                             TaxPercentage = pp.TaxPercentage,
                             Dealers = (from d in _context.Dealers
										join dpp in _context.ProductPriceAndDealers on d.Id equals dpp.DealerId
										where dpp.ProductPriceId == pp.Id && d.State != EntityState.Deleted && dpp.State != EntityState.Deleted
										select new DealerModel
										{
											CreatedDate = d.CreatedDate,
											State = d.State,
											FullAdress = d.FullAdress,
											Name = d.Name,
											Id = d.Id,
										}).ToList() ?? new(),
                         };

            return prices;
        }
        public override ProductPriceModel GetById(int id)
        {
            var price = (from pp in _context.ProductPrices
                         join p in _context.Products on pp.ProductId equals p.Id
                         where pp.Id == id
                            && pp.State != EntityState.Deleted
							&& p.State != EntityState.Deleted
                         select new ProductPriceModel
                         {
                             CreatedDate = pp.CreatedDate,
                             State = pp.State,
                             SellingPrice = pp.SellingPrice,
                             Id = pp.Id,
                             Product = p ?? new(),
                             ProductId = pp.ProductId,
                             ProductionPrice = pp.ProductionPrice,
                             TaxPrice = pp.TaxPrice,
                             ValidUntil = pp.ValidUntil,
                             Description = pp.Description,
                             DiscountedPrice = pp.DiscountedPrice,
                             DiscountPercentage = pp.DiscountPercentage,
                             TaxPercentage = pp.TaxPercentage,
                             Dealers = (from d in _context.Dealers
										join dpp in _context.ProductPriceAndDealers on d.Id equals dpp.DealerId
										where dpp.ProductPriceId == pp.Id && d.State != EntityState.Deleted && dpp.State != EntityState.Deleted
										select new DealerModel
										{
											CreatedDate = d.CreatedDate,
											State = d.State,
											FullAdress = d.FullAdress,
											Name = d.Name,
											Id = d.Id,
										}).ToList() ?? new(),
						 }).FirstOrDefault();

            return price ?? new();
        }

        public override HttpStatusCode Create(ProductPriceModel Thing)
        {
            var result = base.Create(Thing);
            _dealerConnection.CreateConnections(Thing.Id, Thing.Dealers.Select(x => x.Id).ToList());
            
            return result;
        }

		public override HttpStatusCode Update(ProductPriceModel Thing)
		{
            var result = base.Update(Thing);
            _dealerConnection.UpdateConnections(Thing.Id, Thing.Dealers.Select(x => x.Id).ToList()); 
            
            return result;
		}
		public override HttpStatusCode Delete(int id)
		{
            _dealerConnection.DeleteConnections(id);
            return base.Delete(id); 
		}
	}
}
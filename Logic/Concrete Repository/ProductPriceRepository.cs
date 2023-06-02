using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository
{
	public class ProductPriceRepository : BaseRepository<ProductPriceModel>, IProductPriceRepository
	{
		private readonly Context _context;

		public ProductPriceRepository(Context context) : base(context)
		{
			_context = context;
		}

        public override IEnumerable<ProductPriceModel> GetAll()
        {
			var prices = from pp in _context.ProductPrices
						 join p in _context.Products on pp.ProductId equals p.Id
						 where pp.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
							&& p.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
						 select new ProductPriceModel
						 {
							 CreatedDate = pp.CreatedDate,
							 State = pp.State,
							 SellingPrice = pp.SellingPrice,
							 Id = pp.Id,
							 IsDiscounted = pp.IsDiscounted,
							 Product = p ?? new(),
							 ProductId = pp.ProductId,
							 ProductionPrice = pp.ProductionPrice,
							 TaxPrice = pp.TaxPrice,
							 ValidUntil = pp.ValidUntil,
							 Dealers = new List<DealerModel>()
						 };

            return prices;
        }

		public override ProductPriceModel GetById(int id)
		{
			var price = (from pp in _context.ProductPrices
						 join p in _context.Products on pp.ProductId equals p.Id
						 where pp.Id == id
							&& pp.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
							&& p.State != Microsoft.EntityFrameworkCore.EntityState.Deleted
						 select new ProductPriceModel
						 {
							 CreatedDate = pp.CreatedDate,
							 State = pp.State,
							 SellingPrice = pp.SellingPrice,
							 Id = pp.Id,
							 IsDiscounted = pp.IsDiscounted,
							 Product = p ?? new(),
							 ProductId = pp.ProductId,
							 ProductionPrice = pp.ProductionPrice,
							 TaxPrice = pp.TaxPrice,
							 ValidUntil = pp.ValidUntil,
							 Dealers = new() //TODO IDK SEND HELP
						 }).FirstOrDefault();

			return price ?? new();
		}
	}
}

using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository;

public class ProductPriceAndDealersRepository : BaseRepository<ProductPriceAndDealers>, IProductPriceAndDealersRepository
{
	private readonly Context _context;

	public ProductPriceAndDealersRepository(Context context) : base(context)
	{
		_context = context;
	}

    public override IEnumerable<ProductPriceAndDealers> GetAll()
    {
		var priceAndDealers = from pad in _context.ProductPriceAndDealers
							  

        return base.GetAll();
    }
}

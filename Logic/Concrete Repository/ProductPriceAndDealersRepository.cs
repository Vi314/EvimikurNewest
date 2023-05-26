﻿using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
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
							  join p in _context.ProductPrices on pad.ProductPriceId equals p.Id
							  join d in _context.Dealers on pad.DealerId equals d.Id
							  where pad.State != EntityState.Deleted
								&& p.State != EntityState.Deleted
								&& d.State != EntityState.Deleted
							  select new ProductPriceAndDealers
							  {
								  CreatedDate = pad.CreatedDate,
								  Dealer = d,
								  DealerId = p.Id,
								  Id = pad.Id,
								  ProductPrice = p,
								  State = pad.State,
								  ProductPriceId = pad.ProductPriceId,
							  };
							  
        return priceAndDealers;
    }
}

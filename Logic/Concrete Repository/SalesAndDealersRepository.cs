using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repository;

public class SalesAndDealersRepository : BaseRepository<SalesAndDealers>, ISalesAndDealersRepository
{
	Context _context;
	public SalesAndDealersRepository(Context context) : base(context)
	{
		_context = context;
	}

	//TODO linQ join ile metod yazılcak
	public IEnumerable<SalesAndDealers> GetAllJoint()
	{ 
		var result  = from SalesAndDealer in _context.SalesAndDealers 
					join dealer in _context.Dealers on SalesAndDealer.DealerId equals dealer.Id
					select new {
						dealer.Name,
						SalesAndDealer.SaleId
					};
		
		return null;
	}
}



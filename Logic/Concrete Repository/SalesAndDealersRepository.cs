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

public class SalesAndDealersRepository : BaseRepository<SalesAndDealersModel>, ISalesAndDealersRepository
{
	Context _context;
	public SalesAndDealersRepository(Context context) : base(context)
	{
		_context = context;
	}

	public IEnumerable<SalesAndDealersModel> GetAll(int saleId)
	{ 
		var result = _context.SalesAndDealers.Where(x =>x.SaleId == saleId).ToList();
		return result;
	}
}

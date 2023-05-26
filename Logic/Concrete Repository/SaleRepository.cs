using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository;

public class SaleRepository : BaseRepository<Sale>, ISaleRepository
{
    private readonly Context _context;

    public SaleRepository(Context context) : base(context)
    {
        _context = context;
    }

    public override IEnumerable<Sale> GetAll()
    {
        var sales = from s in _context.Sales
                    where s.State != EntityState.Deleted
                    select new Sale
                    {
                        State = s.State,
                        IsForAllDealers = s.IsForAllDealers,
                        StartDate = s.StartDate,
                        CreatedDate = s.CreatedDate,
                        Description = s.Description,
                        Discount = s.Discount,
                        EndDate = s.EndDate,
                        Id = s.Id,
                        IsForAllProducts = s.IsForAllProducts,
                        //Dealers = s.Dealers
                        //Products = s.Products
                        //TODO IS THAT ANOTHER TODO WITHOUT AN EXPLANATION I SEE IN THE DISTANCE, OR A MIRAGE OF SANITY I LOST LONG AGO ?
                    };

        return sales;
    }

	public override Sale GetById(int id)
	{
		var sale = (from s in _context.Sales
					where s.Id == id 
                    && s.State != EntityState.Deleted
					select new Sale
					{
						State = s.State,
						IsForAllDealers = s.IsForAllDealers,
						StartDate = s.StartDate,
						CreatedDate = s.CreatedDate,
						Description = s.Description,
						Discount = s.Discount,
						EndDate = s.EndDate,
						Id = s.Id,
						IsForAllProducts = s.IsForAllProducts,
					}).FirstOrDefault();

		return sale;
	}
}

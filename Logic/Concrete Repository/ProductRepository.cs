using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Repository
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<ProductModel> GetAll()
        {
            var products = from p in _context.Products
                           join c in _context.Categories on p.CategoryId equals c.Id into sc
                           from c in sc.DefaultIfEmpty()
                           where p.State != EntityState.Deleted
                          && c.State != EntityState.Deleted
                           select new ProductModel
                           {
                               Category = c ?? new CategoryModel(),
                               ProductName = p.ProductName,
                               PriceAdvantageGrade = p.PriceAdvantageGrade,
                               CategoryId = p.CategoryId,
                               PotentialSalesGrade = p.PotentialSalesGrade,
                               LooksGrade = p.LooksGrade,
                               InnovativeGrade = p.InnovativeGrade,
                               FunctionalityGrade = p.FunctionalityGrade,
                               State = p.State,
                               UsabilityGrade = p.UsabilityGrade,
                               Id = p.Id,
                               Description = p.Description,
                               CreatedDate = p.CreatedDate,
                               Sales = new(), //TODO IDK AGAIN PLEASE SEND HELP
                           };

            return products;
        }

		public override ProductModel GetById(int id)
		{
			var product = (from p in _context.Products
						   join c in _context.Categories on p.CategoryId equals c.Id into sc
						   from c in sc.DefaultIfEmpty()
						   where p.Id == id 
                           && p.State != EntityState.Deleted
						  && c.State != EntityState.Deleted
						   select new ProductModel
						   {
							   Category = c == null ? new CategoryModel() : c,
							   ProductName = p.ProductName,
							   PriceAdvantageGrade = p.PriceAdvantageGrade,
							   CategoryId = p.CategoryId,
							   PotentialSalesGrade = p.PotentialSalesGrade,
							   LooksGrade = p.LooksGrade,
							   InnovativeGrade = p.InnovativeGrade,
							   FunctionalityGrade = p.FunctionalityGrade,
							   State = p.State,
							   UsabilityGrade = p.UsabilityGrade,
							   Id = p.Id,
							   Description = p.Description,
							   CreatedDate = p.CreatedDate,
							   Sales = new(), //TODO IDK AGAIN PLEASE SEND HELP
						   }).FirstOrDefault();

			return product ?? new();
		}
	}
}

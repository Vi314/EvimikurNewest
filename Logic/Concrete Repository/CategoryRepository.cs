using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Logic.Concrete_Repository
{
	public class CategoryRepository : BaseRepository<CategoryModel>, ICategoryRepository
	{
		private readonly Context _context;
		public CategoryRepository(Context context) : base(context)
		{
			_context = context;
		}
        public override IEnumerable<CategoryModel> GetAll()
        {
            var category = (from c in _context.Categories
                           where c.State != EntityState.Deleted
                           select new CategoryModel
                           {
                               CreatedDate = c.CreatedDate,
                               Description = c.Description,
                               Id = c.Id,
                               Name = c.Name,
                               State = c.State,
                           });
            return category ;
        }
        public override CategoryModel GetById(int id)
        {
            var category = (from c in _context.Categories
                           where c.State != EntityState.Deleted
                               && c.Id == id
                           select new CategoryModel
                           {
                               CreatedDate = c.CreatedDate,
                               Description = c.Description,
                               Id = c.Id,
                               Name = c.Name,
                               State = c.State,
                           }).FirstOrDefault();

            return category ?? new();
        }
    }
}

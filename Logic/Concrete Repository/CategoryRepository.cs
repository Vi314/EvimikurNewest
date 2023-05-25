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
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		private readonly Context _context;
		public CategoryRepository(Context context) : base(context)
		{
			_context = context;
		}
        public override IEnumerable<Category> GetAll()
        {
            var category = from c in _context.Categories
                           where c.State != EntityState.Deleted
                           select new Category
                           {
                               CreatedDate = c.CreatedDate,
                               Description = c.Description,
                               Id = c.Id,
                               Name = c.Name,
                               State = c.State,
                           };
            return category;
        }
        public override Category GetById(int id)
        {
            var category = (Category)(from c in _context.Categories
                           where c.State != EntityState.Deleted
                               && c.Id == id
                           select new Category
                           {
                               CreatedDate = c.CreatedDate,
                               Description = c.Description,
                               Id = c.Id,
                               Name = c.Name,
                               State = c.State,
                           });

            return category;
        }
    }
}

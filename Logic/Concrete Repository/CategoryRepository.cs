﻿using DataAccess;
using Entity.Entity;
using Logic.Abstract_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return base.GetAll();
        }
        public override Category GetById(int id)
        {
            return base.GetById(id);
        }
    }
}

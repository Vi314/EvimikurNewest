using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Repository;

namespace Logic.Concrete_Service
{ 
    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public string CreateOne(Category category)
        {
            try
            {
                return _repository.Create(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string UpdateOne(Category category)
        {
            try
            {
                return _repository.Update(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string DeleteCategory(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
	        try
	        {
		        return _repository.GetById(id);

			}
			catch (Exception e)
	        {
		        Console.WriteLine(e);
		        return null;
	        }
        }
    }
}

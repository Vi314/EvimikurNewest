using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using Logic.Concrete_Repository;

namespace Logic.Concrete_Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public HttpStatusCode CreateOne(CategoryModel category)
    {
        try
        {
            return _repository.Create(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode UpdateOne(CategoryModel category)
    {
        try
        {
            return _repository.Update(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public HttpStatusCode DeleteCategory(int id)
    {
        try
        {
            return _repository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return HttpStatusCode.BadRequest;
        }
    }

    public IEnumerable<CategoryModel> GetCategories()
    {
        return _repository.GetAll();
    }

    public CategoryModel GetById(int id)
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

	public HttpStatusCode CreateRange(IEnumerable<CategoryModel> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<CategoryModel> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}

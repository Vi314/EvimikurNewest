using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _repository;

	public CategoryService(ICategoryRepository repository)
	{
		_repository = repository;
	}

	public HttpStatusCode CreateOne(Category category)
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

	public HttpStatusCode UpdateOne(Category category)
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

	public HttpStatusCode CreateRange(IEnumerable<Category> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode UpdateRange(IEnumerable<Category> Thing)
	{
		throw new NotImplementedException();
	}

	public HttpStatusCode DeleteRange(IEnumerable<int> id)
	{
		throw new NotImplementedException();
	}
}
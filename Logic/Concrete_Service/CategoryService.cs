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

    public HttpStatusCode Create(CategoryModel category)
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

    public HttpStatusCode Update(CategoryModel category)
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

    public HttpStatusCode Delete(int id)
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

    public IEnumerable<CategoryModel> GetAll()
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
            return new();
        }
    }

    public HttpStatusCode CreateRange(IEnumerable<CategoryModel> Thing)
    {
        return _repository.CreateRange(Thing);
    }

    public HttpStatusCode UpdateRange(IEnumerable<CategoryModel> Thing)
    {
        return _repository.UpdateRange(Thing);
    }

    public HttpStatusCode DeleteRange(IEnumerable<int> id)
    {
        return _repository.DeleteRange(id);
    }
}
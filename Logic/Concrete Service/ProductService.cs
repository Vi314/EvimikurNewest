using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class ProductService:IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public string CreateOne(Product product)
    {
        try
        {
            return _repository.Create(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string UpdateOne(Product product)
    {
        try
        {
            return _repository.Update(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string DeleteProduct(int id)
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

    public IEnumerable<Product> GetProducts()
    {
        return _repository.GetAll();
    }
    public Product GetById(int id)
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

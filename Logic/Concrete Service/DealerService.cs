using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;

namespace Logic.Concrete_Service;

public class DealerService:IDealerService
{
    private readonly IDealerRepository _repository;

    public DealerService(IDealerRepository repository)
    {
        _repository = repository;
    }
    public string CreateOne(Dealer dealer)
    {
        try
        {
            return _repository.Create(dealer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string UpdateOne(Dealer dealer)
    {
        try
        {
            return _repository.Update(dealer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return e.Message;
        }
    }

    public string DeleteDealer(int id)
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

    public IEnumerable<Dealer> GetDealers()
    {
        return _repository.GetAll();
    }
    public Dealer GetById(int id)
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

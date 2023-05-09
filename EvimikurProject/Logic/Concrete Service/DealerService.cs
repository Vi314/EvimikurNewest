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
    public class DealerService:IDealerService
    {
        private readonly IRepository<Dealer> _repository;

        public DealerService(IRepository<Dealer> repository)
        {
            _repository = repository;
        }
        public string CreateDealer(Dealer dealer)
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

        public string UpdateDealer(Dealer dealer)
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
}

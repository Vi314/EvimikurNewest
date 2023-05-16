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
    public class OrderDetailsService:IOrderDetailsService
    {
        private readonly IRepository<OrderDetails> _repository;

        public OrderDetailsService(IRepository<OrderDetails> repository)
        {
            _repository = repository;
        }

        public string CreateOne(OrderDetails orderDetails)
        {
            try
            {
                return _repository.Create(orderDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string UpdateOne(OrderDetails orderDetails)
        {
            try
            {
                return _repository.Update(orderDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string DeleteOrderDetails(int id)
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

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            return _repository.GetAll();
        }
        public OrderDetails GetById(int id)
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

using Entity.Entity;
using Logic.Abstract_Service;
using Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Concrete_Service
{
    public class SaleService : ISaleService
    {
        private readonly IRepository<Sale> _repository;
		private readonly IDealerService _dealerService;
		private readonly IProductService _productService;

		public SaleService(IRepository<Sale> repository,IDealerService dealerService, IProductService productService)
        {
            _repository = repository;
			_dealerService = dealerService;
			_productService = productService;
		}
        

        public string CreateOne(Sale sale, List<int> dealerId, List<int> productId)
        {
            try
            {
                foreach (var item in dealerId)
                {
                    var saleDealer = new SalesAndDealers
                    {
                    };
                    sale.Dealers.Add(_dealerService.GetById(item));
                }
                foreach (var item in productId)
                {
					sale.Products.Add(_productService.GetById(item));
				}

				return _repository.Create(sale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }
        }

        public string DeleteOne(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }
        }

        public IEnumerable<Sale> GetAll()
        {
            return _repository.GetAll();
        }

        public Sale GetById(int id)
        {
            return _repository.GetById(id);
        }

        public string UpdateOne(Sale sale, List<int> dealerId, List<int> productId)
        {
            try
            {
                return _repository.Update(sale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }
        }

		string ISaleService.CreateOne(Sale sale)
		{
			try
			{
				return _repository.Create(sale);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.ToString();
			}
		}

		string ISaleService.UpdateOne(Sale sale)
		{
			try
			{
				return _repository.Update(sale);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return e.ToString();
			}
		}
	}
}

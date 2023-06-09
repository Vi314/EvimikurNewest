﻿using Entity.ConnectionEntity;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using System.Net;

namespace Logic.Concrete_Service
{
    public class ProductPriceAndDealersService : IProductPriceAndDealersService
    {
        private readonly IProductPriceAndDealersRepository _repository;

        public ProductPriceAndDealersService(IProductPriceAndDealersRepository repository)
        {
            _repository = repository;
        }

        public HttpStatusCode Create(ProductPriceAndDealersModel thing)
        {
            try
            {
                return _repository.Create(thing);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return HttpStatusCode.BadRequest;
            }
        }

        public HttpStatusCode CreateRange(IEnumerable<ProductPriceAndDealersModel> Thing)
        {
            try
            {
                return _repository.CreateRange(Thing);
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
            { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public HttpStatusCode DeleteRange(IEnumerable<int> id)
        {
            try { return _repository.DeleteRange(id); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public IEnumerable<ProductPriceAndDealersModel> GetAll()
        {
            try { return _repository.GetAll(); } catch (Exception e) { Console.WriteLine(e); throw; }
        }

        public ProductPriceAndDealersModel GetById(int id)
        {
            try { return _repository.GetById(id); } catch (Exception e) { Console.WriteLine(e); throw; }
        }

        public HttpStatusCode Update(ProductPriceAndDealersModel thing)
        {
            try { return _repository.Update(thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }

        public HttpStatusCode UpdateRange(IEnumerable<ProductPriceAndDealersModel> Thing)
        {
            try { return _repository.UpdateRange(Thing); } catch (Exception e) { Console.WriteLine(e); return HttpStatusCode.BadRequest; }
        }
    }
}
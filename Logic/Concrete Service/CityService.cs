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
    public class CityService:ICityService
    {
        private readonly IRepository<City> _repository;

        public CityService(IRepository<City> repository)
        {
            _repository = repository;
        }
        public string CreateCity(City city)
        {
            try
            {
                return _repository.Create(city);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string UpdateCity(City city)
        {
            try
            {
                return _repository.Update(city);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string DeleteCity(int id)
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

        public IEnumerable<City> GetCities()
        {
            return _repository.GetAll();
        }
        public City GetById(int id)
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

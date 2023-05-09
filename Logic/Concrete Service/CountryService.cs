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
    public class CountryService:ICountryService
    {
        private readonly IRepository<Country> _repository;

        public CountryService(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public string CreateCountry(Country country)
        {
            try
            {
                return _repository.Create(country);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string UpdateCountry(Country country)
        {
            try
            {
                return _repository.Update(country);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string DeleteCountry(int id)
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

        public IEnumerable<Country> GetCountries()
        {
            return _repository.GetAll();
        }
        public Country GetById(int id)
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

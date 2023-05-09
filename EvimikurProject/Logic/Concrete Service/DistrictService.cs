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
    public class DistrictService:IDistrictService
    {
        private readonly IRepository<District> _repository;

        public DistrictService(IRepository<District> repository)
        {
            _repository = repository;
        }
        public string CreateDistrict(District district)
        {
            try
            {
                return _repository.Create(district);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string UpdateDistrict(District district)
        {
            try
            {
                return _repository.Update(district);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e.Message;
            }
        }

        public string DeleteDistrict(int id)
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

        public IEnumerable<District> GetDistricts()
        {
            return _repository.GetAll();
        }
        public District GetById(int id)
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

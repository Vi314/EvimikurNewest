using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface ICityService
    {
        string CreateCity(City city);
        string UpdateCity(City city);
        string DeleteCity(int id);
        IEnumerable<City> GetCities();

        City GetById(int id);
    }
}
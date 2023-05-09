using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface ICountryService
    {
        string CreateCountry(Country country);
        string UpdateCountry(Country country);
        string DeleteCountry(int id);
        IEnumerable<Country> GetCountries();
        Country GetById(int id);

}
}
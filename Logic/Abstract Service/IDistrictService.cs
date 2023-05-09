using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IDistrictService
    {
        string CreateDistrict(District district);
        string UpdateDistrict(District district);
        string DeleteDistrict(int id);
        IEnumerable<District> GetDistricts();
        District GetById(int id);

}
}
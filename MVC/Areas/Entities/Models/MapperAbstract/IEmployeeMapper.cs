using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IEmployeeMapper
    {
        public Employee ToEmployee(EmployeeDTO dto, IEnumerable<Dealer> dealers);
        public EmployeeDTO FromEmployee(Employee entity, IEnumerable<Dealer> dealers);

    }
}
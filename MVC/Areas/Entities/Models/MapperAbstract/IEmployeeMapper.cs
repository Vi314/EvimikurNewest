using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IEmployeeMapper
    {
        public Employee FromDto(EmployeeDTO dto);
        public EmployeeDTO FromEntity(Employee entity);

    }
}
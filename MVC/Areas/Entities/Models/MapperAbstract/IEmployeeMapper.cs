using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IEmployeeMapper
    {
        public EmployeeModel FromDto(EmployeeDTO dto);

        public EmployeeDTO FromEntity(EmployeeModel entity);
    }
}
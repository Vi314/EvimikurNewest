using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IEmployeeInsuranceActionMapper
    {
        public EmployeeInsuranceActionModel FromDto(EmployeeInsuranceActionDTO insuranceActionDTO);

        public EmployeeInsuranceActionDTO FromEntity(EmployeeInsuranceActionModel insuranceAction);
    }
}
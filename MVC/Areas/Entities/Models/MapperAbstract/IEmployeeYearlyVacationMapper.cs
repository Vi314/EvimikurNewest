using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;
public interface IEmployeeYearlyVacationMapper
{
    public EmployeeYearlyVacationDTO FromEntity(EmployeeYearlyVacation entity);
    public EmployeeYearlyVacation FromDto(EmployeeYearlyVacationDTO Dto);

}

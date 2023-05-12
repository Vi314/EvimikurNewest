using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;
public interface IEmployeeYearlyVacationMapper
{
    public EmployeeYearlyVacationDTO FromEmpYearlyVacation(EmployeeYearlyVacation entity, List<Employee> employees);
    public EmployeeYearlyVacation ToEmpYearlyVacation(EmployeeYearlyVacationDTO Dto, List<Employee> employees);

}

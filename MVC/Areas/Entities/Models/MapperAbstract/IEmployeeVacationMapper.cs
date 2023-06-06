using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IEmployeeVacationMapper
    {
        public EmployeeVacationModel FromDto(EmployeeVacationDTO vacationDto);

        public EmployeeVacationDTO FromEntity(EmployeeVacationModel vacation);
    }
}
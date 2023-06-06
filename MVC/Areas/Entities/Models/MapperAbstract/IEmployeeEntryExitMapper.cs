using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
    public interface IEmployeeEntryExitMapper
    {
        public EmployeeEntryExitModel FromDto(EmployeeEntryExitDTO entryExitDTO);

        public EmployeeEntryExitDTO FromEntity(EmployeeEntryExitModel entryExit);
    }
}
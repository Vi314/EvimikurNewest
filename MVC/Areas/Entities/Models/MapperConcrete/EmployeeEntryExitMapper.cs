using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeEntryExitMapper : IEmployeeEntryExitMapper
    {
        public EmployeeEntryExitModel FromDto(EmployeeEntryExitDto entryExitDTO)
        {
            var entryExit = new EmployeeEntryExitModel
            {
                Id = entryExitDTO.Id,
                EntryTime = entryExitDTO.Entry,
                ExitTime = entryExitDTO.Exit,
                EmployeeId = entryExitDTO.EmployeeId,
            };
            return entryExit;
        }

        public IEnumerable<EmployeeEntryExitModel> FromDtoRange(IEnumerable<EmployeeEntryExitDto> dtos)
        {
            foreach (var d in dtos)
            {
                yield return FromDto(d);
            }
        }

        public EmployeeEntryExitDto FromEntity(EmployeeEntryExitModel entryExit)
        {
            var entryExitDTO = new EmployeeEntryExitDto
            {
                Id = entryExit.Id,
                Entry = entryExit.EntryTime,
                Exit = entryExit.ExitTime,
                EmployeeName = entryExit.Employee.FirstName + " " + entryExit.Employee.LastName,
            };
            return entryExitDTO;
        }

        public IEnumerable<EmployeeEntryExitDto> FromEntityRange(IEnumerable<EmployeeEntryExitModel> entities)
        {
            foreach (var entity in entities)
            {
                yield return FromEntity(entity);
            }
        }

    }
}
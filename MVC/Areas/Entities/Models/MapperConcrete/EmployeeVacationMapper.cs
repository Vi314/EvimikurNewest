using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeVacationMapper : IEmployeeVacationMapper
    {
        public EmployeeVacationDto FromEntity(EmployeeVacationModel vacation)
        {
            var dto = new EmployeeVacationDto
            {
                Id = vacation.Id,
                IsApproved = vacation.IsApproved,
                VacationDuration = vacation.VacationDuration,
                VacationStart = vacation.VacationStart,
                VacationEnd = vacation.VacationEnd,
                EmployeeName = vacation.Employee.FirstName,
                EmployeeId = vacation.EmployeeId,
            };
            return dto;
        }

        public EmployeeVacationModel FromDto(EmployeeVacationDto vacationDto)
        {
            var empVacation = new EmployeeVacationModel
            {
                Id = vacationDto.Id,
                IsApproved = vacationDto.IsApproved,
                VacationDuration = vacationDto.VacationDuration,
                VacationStart = vacationDto.VacationStart,
                VacationEnd = vacationDto.VacationEnd,
                EmployeeId = vacationDto.EmployeeId
            };
            return empVacation;
        }

        public IEnumerable<EmployeeVacationDto> FromEntityRange(IEnumerable<EmployeeVacationModel> entities)
        {
            foreach (var entity in entities)
            {
                yield return FromEntity(entity);
            }
        }

        public IEnumerable<EmployeeVacationModel> FromDtoRange(IEnumerable<EmployeeVacationDto> dtos)
        {
            foreach (var dto in dtos)
            {
                yield return FromDto(dto);
            }
        }
    }
}
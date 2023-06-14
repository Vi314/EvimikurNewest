using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeYearlyVacationMapper : IEmployeeYearlyVacationMapper
    {
        public EmployeeYearlyVacationDto FromEntity(EmployeeYearlyVacationModel entity)
        {
            EmployeeYearlyVacationDto dto = new EmployeeYearlyVacationDto
            {
                Id = entity.Id,
                VacationDaysUsed = entity.VacationDaysUsed,
                Year = entity.Year,
                YearlyVacationDays = entity.YearlyVacationDays,
                EmployeeName = entity.Employee.FirstName + " " + entity.Employee.LastName,
                EmployeeId = entity.EmployeeId,
            };
            return dto;
        }

        public EmployeeYearlyVacationModel FromDto(EmployeeYearlyVacationDto Dto)
        {
            EmployeeYearlyVacationModel entity = new EmployeeYearlyVacationModel
            {
                Id = Dto.Id,
                VacationDaysUsed = Dto.VacationDaysUsed,
                Year = Dto.Year,
                YearlyVacationDays = Dto.YearlyVacationDays,
                EmployeeId = Dto.EmployeeId
            };
            return entity;
        }

        public IEnumerable<EmployeeYearlyVacationDto> FromEntityRange(IEnumerable<EmployeeYearlyVacationModel> entities)
        {
            foreach (var item in entities)
            {
                yield return FromEntity(item);
            }
        }

        public IEnumerable<EmployeeYearlyVacationModel> FromDtoRange(IEnumerable<EmployeeYearlyVacationDto> dtos)
        {
            foreach (var item in dtos)
            {
                yield return FromDto(item);
            }
        }
    }
}
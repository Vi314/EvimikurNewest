using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeYearlyVacationMapper : IEmployeeYearlyVacationMapper
    {
        public EmployeeYearlyVacationDTO FromEntity(EmployeeYearlyVacation entity)
        {
            EmployeeYearlyVacationDTO dto = new EmployeeYearlyVacationDTO
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

        public EmployeeYearlyVacation FromDto(EmployeeYearlyVacationDTO Dto)
        {
            EmployeeYearlyVacation entity = new EmployeeYearlyVacation
            {
                Id = Dto.Id,
                VacationDaysUsed = Dto.VacationDaysUsed,
                Year = Dto.Year,
                YearlyVacationDays = Dto.YearlyVacationDays,
                EmployeeId = Dto.EmployeeId
            };
            return entity;
        }
    }
}

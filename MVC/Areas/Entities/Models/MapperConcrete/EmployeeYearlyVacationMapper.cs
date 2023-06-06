using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeYearlyVacationMapper : IEmployeeYearlyVacationMapper
    {
        public EmployeeYearlyVacationDTO FromEntity(EmployeeYearlyVacationModel entity)
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

        public EmployeeYearlyVacationModel FromDto(EmployeeYearlyVacationDTO Dto)
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
    }
}
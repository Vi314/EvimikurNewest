using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeYearlyVacationMapper : IEmployeeYearlyVacationMapper
    {
        public EmployeeYearlyVacationDTO FromEmpYearlyVacation(EmployeeYearlyVacation entity, List<Employee> employees)
        {
            EmployeeYearlyVacationDTO dto = new EmployeeYearlyVacationDTO
            {
                Id = entity.Id,
                VacationDaysUsed = entity.VacationDaysUsed,
				Year = entity.Year,
                YearlyVacationDays = entity.YearlyVacationDays,
            };
            dto.EmployeeName = employees.Where(x => x.Id == entity.EmployeeId).Select(x => x.FirstName).FirstOrDefault();
            return dto;
        }

        public EmployeeYearlyVacation ToEmpYearlyVacation(EmployeeYearlyVacationDTO Dto, List<Employee> employees)
        {
            EmployeeYearlyVacation entity = new EmployeeYearlyVacation
            {
                Id = Dto.Id,
                VacationDaysUsed = Dto.VacationDaysUsed,
                Year = Dto.Year,
                YearlyVacationDays = Dto.YearlyVacationDays,
            };
            entity.EmployeeId = employees.Where(x=>x.FirstName == Dto.EmployeeName).Select(x=>x.Id).FirstOrDefault();
            return entity;
        }
    }
}

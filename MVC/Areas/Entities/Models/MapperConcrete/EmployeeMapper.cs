using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete;

public class EmployeeMapper : IEmployeeMapper
{
    public EmployeeModel FromDto(EmployeeDto dto)
    {
        var employee = new EmployeeModel
        {
            Id = dto.Id,
            FirstName = dto.FirstName.Trim(),
            LastName = dto.LastName.Trim(),
            Department = dto.Department.Trim(),
            EducationLevel = dto.EducationLevel.Trim(),
            Title = dto.Title.Trim(),
            FullAddress = dto.FullAddress.Trim(),
            HiredDate = dto.HiredDate,
            DealerId = dto.DealerId,
        };
        return employee;
    }

    public IEnumerable<EmployeeModel> FromDtoRange(IEnumerable<EmployeeDto> dtos)
    {
        foreach (var dto in dtos) 
        {
            yield return FromDto(dto);
        }
    }

    public EmployeeDto FromEntity(EmployeeModel entity)
    {
        var employeeDTO = new EmployeeDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Department = entity.Department,
            EducationLevel = entity.EducationLevel,
            Title = entity.Title,
            HiredDate = entity.HiredDate,
            FullAddress = entity.FullAddress,
            DealerModel = entity.Dealer.Name,
            DealerId = entity.DealerId,
        };

        return employeeDTO;
    }

    public IEnumerable<EmployeeDto> FromEntityRange(IEnumerable<EmployeeModel> entities)
    {
        foreach (var entity in entities)
        {
            yield return FromEntity(entity);
        }
    }
}
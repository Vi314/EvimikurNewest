using Entity.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeMapper : IEmployeeMapper
	{
		public Employee FromDto(EmployeeDTO dto)
		{
			var employee = new Employee
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
		public EmployeeDTO FromEntity(Employee entity)
		{
			var employeeDTO = new EmployeeDTO
			{
				Id = entity.Id,
				FirstName = entity.FirstName,
				LastName = entity.LastName,
				Department = entity.Department,
				EducationLevel = entity.EducationLevel,
				Title = entity.Title,
				HiredDate = entity.HiredDate,
				FullAddress = entity.FullAddress,
				Dealer = entity.Dealer.Name,
				DealerId = entity.DealerId,
			};

			return employeeDTO;
		}
	}
}

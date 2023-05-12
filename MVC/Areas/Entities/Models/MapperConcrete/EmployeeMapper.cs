using Entity.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeMapper : IEmployeeMapper
	{
		public Employee ToEmployee(EmployeeDTO dto, IEnumerable<Dealer> dealers)
		{
			var employee = new Employee
			{
				Id = dto.Id,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Department = dto.Department,
				EducationLevel = dto.EducationLevel,
				Title = dto.Title,
				FullAddress = dto.FullAddress,
				HiredDate = dto.HiredDate,
				DealerId = dealers.Where(x => x.Name == dto.Dealer).Select(x => x.Id).FirstOrDefault()

			};
			return employee;
		}
		public EmployeeDTO FromEmployee(Employee entity, IEnumerable<Dealer> dealers)
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
				FullAddress = entity.FullAddress
			};

			if (entity.DealerId != null)
			{
				employeeDTO.Dealer = dealers.Where(x => x.Id == entity.DealerId).Select(x => x.Name).FirstOrDefault();
			}

			return employeeDTO;
		}
	}
}

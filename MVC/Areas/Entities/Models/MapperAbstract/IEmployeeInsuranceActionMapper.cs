using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IEmployeeInsuranceActionMapper
	{
		public EmployeeInsuranceAction FromDto(EmployeeInsuranceActionDTO insuranceActionDTO);
		public EmployeeInsuranceActionDTO FromEntity(EmployeeInsuranceAction insuranceAction);
	}
}

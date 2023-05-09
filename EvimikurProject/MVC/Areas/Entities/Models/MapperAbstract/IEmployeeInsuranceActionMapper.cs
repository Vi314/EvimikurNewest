using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IEmployeeInsuranceActionMapper
	{
		public EmployeeInsuranceAction ToEmployeeInsuranceAction(EmployeeInsuranceActionDTO insuranceActionDTO,List<Employee> employees);
		public EmployeeInsuranceActionDTO FromEmployeeInsuranceAction(EmployeeInsuranceAction insuranceAction, List<Employee> employees);
	}
}

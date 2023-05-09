using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class EmployeeInsuranceActionMapper : IEmployeeInsuranceActionMapper
	{
		public EmployeeInsuranceActionDTO FromEmployeeInsuranceAction(EmployeeInsuranceAction insuranceAction, List<Employee> employees)
		{
			var actDTO = new EmployeeInsuranceActionDTO
			{
				Id = insuranceAction.Id,
				Date = insuranceAction.Date,
				Hospital = insuranceAction.Hospital,
				Operation = insuranceAction.Description,
			};
			actDTO.EmployeeName = employees.Where(x => x.Id == insuranceAction.EmployeeId).Select(x => x.FirstName).FirstOrDefault();
			return actDTO;
		}

		public EmployeeInsuranceAction ToEmployeeInsuranceAction(EmployeeInsuranceActionDTO insuranceActionDTO, List<Employee> employees)
		{
			var act = new EmployeeInsuranceAction
			{
				Id = insuranceActionDTO.Id,
				Date = insuranceActionDTO.Date,
				Hospital = insuranceActionDTO.Hospital,
                Description = insuranceActionDTO.Operation,
			};
			act.EmployeeId = employees.Where(x=>x.FirstName == insuranceActionDTO.EmployeeName).Select(x=>x.Id).FirstOrDefault();
			return act;
		}
	}
}

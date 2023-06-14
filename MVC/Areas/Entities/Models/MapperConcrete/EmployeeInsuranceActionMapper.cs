using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class EmployeeInsuranceActionMapper : IEmployeeInsuranceActionMapper
    {
        public EmployeeInsuranceActionDTO FromEntity(EmployeeInsuranceActionModel insuranceAction)
        {
            var actDTO = new EmployeeInsuranceActionDTO
            {
                Id = insuranceAction.Id,
                Date = insuranceAction.Date,
                Hospital = insuranceAction.Hospital,
                Operation = insuranceAction.Description,
                EmployeeId = insuranceAction.EmployeeId,
                EmployeeName = insuranceAction.Employee.FirstName + " " + insuranceAction.Employee.LastName,
            };
            return actDTO;
        }

        public EmployeeInsuranceActionModel FromDto(EmployeeInsuranceActionDTO insuranceActionDTO)
        {
            var act = new EmployeeInsuranceActionModel
            {
                Id = insuranceActionDTO.Id,
                Date = insuranceActionDTO.Date,
                Hospital = insuranceActionDTO.Hospital.Trim(),
                Description = insuranceActionDTO.Operation.Trim(),
                EmployeeId = insuranceActionDTO.EmployeeId,
            };
            return act;
        }

        public IEnumerable<EmployeeInsuranceActionDTO> FromEntityRange(IEnumerable<EmployeeInsuranceActionModel> entities)
        {
            foreach (var entity in entities)
            {
                yield return FromEntity(entity);
            }
        }

        public IEnumerable<EmployeeInsuranceActionModel> FromDtoRange(IEnumerable<EmployeeInsuranceActionDTO> dtos)
        {
            foreach (var d in dtos)
            {
                yield return FromDto(d);
            }
        }
    }
}
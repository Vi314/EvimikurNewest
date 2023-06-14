using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete;

public class SupplierMapper : ISupplierMapper
{
    public SupplierModel FromDto(SupplierDto supplierDTO)
    {
        SupplierModel supplier = new SupplierModel
        {
            Id = supplierDTO.Id,
            CompanyName = supplierDTO.CompanyName.Trim(),
            SupplierGrade = supplierDTO.SupplierGrade,
            ApprovalState = supplierDTO.ApprovalState,
            UserId = supplierDTO.UserId,
        };
        return supplier;
    }

    public IEnumerable<SupplierModel> FromDtoRange(IEnumerable<SupplierDto> dtos)
    {
        foreach (var dto in dtos)
        {
            yield return FromDto(dto);
        }
    }

    public SupplierDto FromEntity(SupplierModel supplier)
    {
        SupplierDto supplierDTO = new SupplierDto
        {
            Id = supplier.Id,
            CompanyName = supplier.CompanyName,
            SupplierGrade = supplier.SupplierGrade,
            ApprovalState = supplier.ApprovalState,
            UserId = supplier.UserId,
            UserName = supplier.User.UserName ?? ""
        };
        return supplierDTO;
    }

    public IEnumerable<SupplierDto> FromEntityRange(IEnumerable<SupplierModel> entities)
    {
        foreach (var entity in entities)
        {
            yield return FromEntity(entity);
        }
    }
}
using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;

public interface ISupplierContractMapper
{
    public SupplierContractModel FromDto(SupplierContractDTO dto);
    public SupplierContractDTO FromEntity(SupplierContractModel entity);
}
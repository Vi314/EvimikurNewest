using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;

public interface ISupplierMapper
{
    public SupplierModel FromDto(SupplierDTO supplierDTO);

    public SupplierDTO FromEntity(SupplierModel supplier);
}
using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;

public interface ISupplierMapper
{
    public Supplier FromDto(SupplierDTO supplierDTO);
    public SupplierDTO FromEntity(Supplier supplier);
}
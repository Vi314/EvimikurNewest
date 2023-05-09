using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;

public interface ISupplierMapper
{
    public Supplier ToSupplier(SupplierDTO supplierDTO);
    public SupplierDTO FromSupplier(Supplier supplier);
}
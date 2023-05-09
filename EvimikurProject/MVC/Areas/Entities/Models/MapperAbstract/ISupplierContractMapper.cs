using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract;

public interface ISupplierContractMapper
{
    public SupplierContract ToSupplierContract(SupplierContractDTO supplierContractDTO,IEnumerable<Supplier> suppliers, IEnumerable<Product> products);
    public SupplierContractDTO FromSupplierContract(SupplierContract supplierContract, IEnumerable<Supplier> suppliers, IEnumerable<Product> products);
}
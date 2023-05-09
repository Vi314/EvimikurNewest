using Entity.Entity;
using Logic.Abstract_Service;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class SupplierMapper:ISupplierMapper
    {
        public Supplier ToSupplier(SupplierDTO supplierDTO)
        {
            Supplier supplier = new Supplier
            {
                Id = supplierDTO.Id,
                CompanyName = supplierDTO.CompanyName,
                SupplierGrade = supplierDTO.SupplierGrade,
                ApprovalState = supplierDTO.ApprovalState
            };
            return supplier;
        }

        public SupplierDTO FromSupplier(Supplier supplier)
        {
            SupplierDTO supplierDTO = new SupplierDTO
            {
                Id = supplier.Id,
                CompanyName = supplier.CompanyName.Trim(),
                SupplierGrade = supplier.SupplierGrade,
                ApprovalState = supplier.ApprovalState
            };
            return supplierDTO;
        }
    }
}

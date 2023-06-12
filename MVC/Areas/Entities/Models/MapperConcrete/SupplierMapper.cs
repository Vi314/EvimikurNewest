using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class SupplierMapper : ISupplierMapper
    {
        public SupplierModel FromDto(SupplierDTO supplierDTO)
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

        public SupplierDTO FromEntity(SupplierModel supplier)
        {
            SupplierDTO supplierDTO = new SupplierDTO
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
    }
}
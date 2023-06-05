using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class SupplierContractMapper:ISupplierContractMapper
    {
        public SupplierContractModel FromDto(SupplierContractDTO dto)
        {
            SupplierContractModel entity = new SupplierContractModel
            {
                Id = dto.Id,
                ContractSignDate = Convert.ToDateTime(dto.ContractSignDate),
                ContractEndDate = Convert.ToDateTime(dto.ContractEndDate),
                PaymentDate = Convert.ToDateTime(dto.PaymentDate),
                Amount = dto.Amount,
                ContractState = dto.ContractState,
                Price = dto.Price,
                ShippingCost = dto.ShippingCost,
                SupplierId = dto.SupplierId,
                ProductId = dto.ProductId,
            };
            return entity;
        }

        public SupplierContractDTO FromEntity(SupplierContractModel entity)
        {
            SupplierContractDTO dto = new SupplierContractDTO
            {
                Id = entity.Id,
                ContractSignDate = entity.ContractSignDate,
                ContractEndDate = entity.ContractEndDate,
                PaymentDate = entity.PaymentDate,
                Amount = entity.Amount,
                ContractState = entity.ContractState,
                Price = entity.Price,
                ShippingCost = entity.ShippingCost,
                ProductName = entity.Product.ProductName,
                SupplierName = entity.Supplier.CompanyName,
                SupplierId = entity.SupplierId,
                ProductId = entity.ProductId,
            };
            return dto;
        }
    }
}

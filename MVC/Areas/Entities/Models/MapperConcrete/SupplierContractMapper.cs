using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
    public class SupplierContractMapper:ISupplierContractMapper
    {
        public SupplierContract ToSupplierContract(SupplierContractDTO supplierContractDTO, IEnumerable<Supplier> suppliers,IEnumerable<Product> products)
        {
            SupplierContract supplierContract = new SupplierContract
            {
                Id = supplierContractDTO.Id,
                ContractSignDate = Convert.ToDateTime(supplierContractDTO.ContractSignDate),
                ContractEndDate = Convert.ToDateTime(supplierContractDTO.ContractEndDate),
                PaymentDate = Convert.ToDateTime(supplierContractDTO.PaymentDate),
                Amount = supplierContractDTO.Amount,
                ContractState = supplierContractDTO.ContractState,
                Price = supplierContractDTO.Price,
                ShippingCost = supplierContractDTO.ShippingCost,
            };
            supplierContract.ProductId = products.Where(x => x.ProductName == supplierContractDTO.ProductName).Select(x => x.Id).FirstOrDefault();
            supplierContract.SupplierId = suppliers.Where(x => x.CompanyName == supplierContractDTO.SupplierName)
                .Select(x => x.Id).FirstOrDefault();
            return supplierContract;
        }

        public SupplierContractDTO FromSupplierContract(SupplierContract supplierContract, IEnumerable<Supplier> suppliers, IEnumerable<Product> products)
        {
            SupplierContractDTO supplierContractDTO = new SupplierContractDTO
            {
                Id = supplierContract.Id,
                ContractSignDate = supplierContract.ContractSignDate.ToString().Replace("00:00:00", ""),
                ContractEndDate = supplierContract.ContractEndDate.ToString().Replace("00:00:00", ""),
                PaymentDate = supplierContract.PaymentDate.ToString().Replace("00:00:00", ""),
                Amount = supplierContract.Amount,
                ContractState = supplierContract.ContractState,
                Price = supplierContract.Price,
                ShippingCost = supplierContract.ShippingCost,
            };
            
            if (supplierContract.ProductId != null)
            {
                supplierContractDTO.ProductName = products.Where(x => x.Id == supplierContract.ProductId).Select(x => x.ProductName).FirstOrDefault();
            }
            if (supplierContract.SupplierId != null)
            {
                supplierContractDTO.SupplierName = suppliers.Where(x => x.Id == supplierContract.SupplierId)
                    .Select(x => x.CompanyName).FirstOrDefault();
            }
            return supplierContractDTO;
        }
    }
}

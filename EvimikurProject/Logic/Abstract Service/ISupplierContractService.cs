using Entity.Entity;

namespace Logic.Abstract_Service;

public interface ISupplierContractService
{
	string CreateSupplierContract(SupplierContract supplierContract);
	string UpdateSupplierContract(SupplierContract supplierContract);
	string DeleteSupplierContract(int id);
	IEnumerable<SupplierContract> GetSupplierContracts();
	SupplierContract GetById(int id);
}
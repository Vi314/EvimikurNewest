using Entity.Entity;

namespace Logic.Abstract_Service;

public interface ISupplierContractService
{
	string CreateOne(SupplierContract supplierContract);
	string UpdateOne(SupplierContract supplierContract);
	string DeleteSupplierContract(int id);
	IEnumerable<SupplierContract> GetSupplierContracts();
	SupplierContract GetById(int id);
}
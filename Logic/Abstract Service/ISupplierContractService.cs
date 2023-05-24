using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISupplierContractService
{
	HttpStatusCode CreateRange(IEnumerable<SupplierContract> Thing);
	HttpStatusCode UpdateRange(IEnumerable<SupplierContract> Thing);
	HttpStatusCode DeleteRange(IEnumerable<int> id);

	HttpStatusCode CreateOne(SupplierContract supplierContract);
	HttpStatusCode UpdateOne(SupplierContract supplierContract);
	HttpStatusCode DeleteSupplierContract(int id);
	IEnumerable<SupplierContract> GetSupplierContracts();
	SupplierContract GetById(int id);
}
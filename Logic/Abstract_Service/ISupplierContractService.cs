using Entity.Entity;
using System.Net;

namespace Logic.Abstract_Service;

public interface ISupplierContractService
{
    HttpStatusCode CreateRange(IEnumerable<SupplierContractModel> Thing);

    HttpStatusCode UpdateRange(IEnumerable<SupplierContractModel> Thing);

    HttpStatusCode DeleteRange(IEnumerable<int> id);

    HttpStatusCode CreateOne(SupplierContractModel supplierContract);

    HttpStatusCode UpdateOne(SupplierContractModel supplierContract);

    HttpStatusCode DeleteSupplierContract(int id);

    IEnumerable<SupplierContractModel> GetSupplierContracts();
    IEnumerable<SupplierContractModel> GetSupplierContractsByUser(int userId);

    SupplierContractModel GetById(int id);
}